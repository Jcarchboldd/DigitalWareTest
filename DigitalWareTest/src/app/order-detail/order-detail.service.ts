import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from '../base.service';
import { Observable, lastValueFrom } from 'rxjs';

import { OrderList } from './OrderList';
import { ProductList } from './ProductList';

@Injectable({
  providedIn: 'root',
})
export class OrderDetailService
  extends BaseService<OrderList> {

  arr: any = {};
  myJSONString?: string;

  constructor(
    http: HttpClient) {
    super(http);

  }

  get(orderId: number) {
    var url = this.getUrl("api/Order_Details/" + orderId);
    return this.http.get<OrderList[]>(url).toPromise();
  }

  getProduct() {
    var url = this.getUrl("api/Products/");
    return this.http.get<ProductList[]>(url).toPromise();
  }

  protected put(item: OrderList, orderId: number): Observable<OrderList> {
    var url = this.getUrl("api/Order_Details/" + orderId);
    return this.http.put<OrderList>(url, item);
  }

  protected post(item: OrderList, orderId: number): Observable<OrderList> {
    var url = this.getUrl("api/Order_Details/" + orderId);
    return this.http.post<OrderList>(url, item);
  }

  protected delete(orderId: number, productId: number): Observable<OrderList> {
    var url = this.getUrl("api/Order_Details/" + orderId + "/" + productId);
    return this.http.delete<OrderList>(url);
  }

  sendRequest(method:string, data: any = {}, orderId:number = 0, productId:number = 0): Promise<any> {

    const httpParams = new HttpParams({ fromObject: data });
    let result: any;

    if (method != 'DELETE') {
      this.myJSONString = httpParams.get('values') ?? "";

      this.arr = JSON.parse(this.myJSONString);
    }

    // Según consume el método aplicado
    switch (method) {
      case 'PUT':
        result = this.put(this.arr, orderId);
        break;
      case 'POST':
        result = this.post(this.arr, orderId);
        break;
      case 'DELETE':
        result = this.delete(orderId, productId);
        break;
    }

    return lastValueFrom(result)
      .then((data: any) => (data))
      .catch((e) => {
        throw e && e.error && e.error;
      });
  }

}
