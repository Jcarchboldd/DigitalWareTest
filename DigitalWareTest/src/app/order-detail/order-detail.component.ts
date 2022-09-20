import { Component, Input, AfterViewInit } from '@angular/core';
import {HttpClient, HttpParams,} from '@angular/common/http';
import { environment } from './../../environments/environment';
import { OrderList } from './OrderList';
import CustomStore from 'devextreme/data/custom_store';
import { lastValueFrom } from 'rxjs';

const URL = environment.baseUrl + 'api/Order_Details';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css']
})
export class OrderDetailComponent implements AfterViewInit {
  @Input() key!: number;
  ordersDetails: any = {};
  dataSource: any;
  orderList?: OrderList[];
  productData: any;
  products: any = {};
  arr: any = {};
  myJSONString?: string;

  refreshModes: string[];
  refreshMode: string;
  requests: string[] = [];

  constructor(private httpClient: HttpClient) {
    this.refreshMode = 'reshape';
    this.refreshModes = ['full', 'reshape', 'repaint'];

  }

  sendRequest(url: string, method = 'GET', data: any = {}): any {

    const httpParams = new HttpParams({ fromObject: data });
    let result: any;

    // Si el método  no es para eliminar se obtienen los valalores de la fila
    if (method != 'DELETE') {
      this.myJSONString = httpParams.get('values') ?? "";

      this.arr = JSON.parse(this.myJSONString);
    }
    
    // Según consume el método aplicado
    switch (method) {
      case 'PUT':
        result = this.httpClient.put<OrderList>(URL, this.arr);
        break;
      case 'POST':
        result = this.httpClient.post<OrderList>(url, this.arr);
        break;
      case 'DELETE':
        result = this.httpClient.delete<OrderList>(url, this.arr);
        break;
    }

    return lastValueFrom(result)
      .then((data: any) => (method === 'GET' ? data.data : data))
      .catch((e) => {
        throw e && e.error && e.error;
      });
  }

  // Obtener detalles de la orden
  getOrderDetails() {
    return this.httpClient.get<OrderList[]>(`${URL}/` + this.key).toPromise();

  }

  // Obtener productos del detalle
  getProducts() {
    return this.httpClient.get<OrderList[]>(environment.baseUrl + 'api/Products').toPromise();
  }

  // Por defecto el dx-data-grid no devuelve al CustomStore todos los valores de la fila
  // por lo que se require forzarlo a enviarlos
  updateRow(options: { newData: any; oldData: any; }) {
    options.newData = Object.assign(options.oldData, options.newData);
  }

  // Dado que el Id del producto hace parte de una llave compuesta con el OrderID, se requuere evitar que se
  // se pueda editar la celda; pero que si permita escoger al momento de agregar un nuevo registro
  onEditorPreparing(e: { dataField: string; row: { isNewRow: boolean; }; editorOptions: { readOnly: boolean; }; }) {
    if (e.dataField == 'productID' && e.row.isNewRow != true) {
      e.editorOptions.readOnly = true;
    }
  }

  async ngAfterViewInit() {

    this.ordersDetails = await this.getOrderDetails();
    this.products = await this.getProducts();

    //Configuración del dataSource
    this.dataSource = new CustomStore({
      key: 'productID',
      load: () => this.ordersDetails,
      insert: (values) => this.sendRequest(`${URL}/` + this.key, 'POST', {
        values: JSON.stringify(values),
      }),
      update: (key, values) => this.sendRequest(`${URL}/`, 'PUT', {
        key,
        values: JSON.stringify(values),
      }),
      remove: (key) => this.sendRequest(`${URL}/` + this.key + '/' + key, 'DELETE', {
        key,
      })

    });

    // dataSource del dropdown de los productos
    this.productData = {
      paginate: true,
      store: new CustomStore({
        key: 'Value',
        loadMode: 'raw',
        load: () => this.products,
      }),
    };

  }

}
