import { Component, Input, AfterViewInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import CustomStore from 'devextreme/data/custom_store';
import { OrderDetailService } from './order-detail.service';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css']
})
export class OrderDetailComponent implements AfterViewInit {
  @Input() OrderId!: number;
  ordersDetails: any = {};
  dataSource: any;
  productData: any;
  products: any = {};

  refreshModes: string[];
  refreshMode: string;
  requests: string[] = [];

  constructor(private httpClient: HttpClient, private orderDetailService: OrderDetailService) {
    this.refreshMode = 'reshape';
    this.refreshModes = ['full', 'reshape', 'repaint'];

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

    this.ordersDetails = await this.orderDetailService.get(this.OrderId);
    this.products = await this.orderDetailService.getProduct();

    //Configuración del dataSource
    this.dataSource = new CustomStore({
      key: 'productID',
      load: () => this.ordersDetails,
      insert: (values) => this.orderDetailService.sendRequest('POST', {
        values: JSON.stringify(values),
      }, this.OrderId),
      update: (key, values) => this.orderDetailService.sendRequest('PUT', {
        key,
        values: JSON.stringify(values),
      }, this.OrderId),
      remove: (key) => this.orderDetailService.sendRequest('DELETE', '', this.OrderId, key)
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
