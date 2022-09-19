import { Component, Input, AfterViewInit } from '@angular/core';
import {
  HttpClient, HttpClientModule, HttpHeaders, HttpParams,
} from '@angular/common/http';
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
    const httpOptions = { withCredentials: true, body: httpParams };
    let result: any;

    if (method != 'DELETE') {
      this.myJSONString = httpParams.get('values') ?? "";

      this.arr = JSON.parse(this.myJSONString);
    }
    else {
      this.myJSONString = httpParams.get('values') ?? "";

    }
    
    switch (method) {
      case 'GET':
        result = this.httpClient.get<OrderList[]>(url, httpOptions);
        break;
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
        throw e && e.error && e.error.Message;
      });
  }

  getOrderDetails() {
    return this.httpClient.get<OrderList[]>(`${URL}/` + this.key).toPromise();

  }

  getProducts() {
    return this.httpClient.get<OrderList[]>(environment.baseUrl + 'api/Products').toPromise();
  }

  updateRow(options: { newData: any; oldData: any; }) {
    options.newData = Object.assign(options.oldData, options.newData);
  }

  onEditorPreparing(e: { dataField: string; row: { isNewRow: boolean; }; editorOptions: { readOnly: boolean; }; }) {
    if (e.dataField == 'productID' && e.row.isNewRow != true) {
      e.editorOptions.readOnly = true;
    }
  }

  async ngAfterViewInit() {

    this.ordersDetails = await this.getOrderDetails();
    this.products = await this.getProducts();

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
