import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../services/base.service.details';
import { Observable, lastValueFrom } from 'rxjs';
import { OrderList } from '../Model/OrderList';
import { ProductList } from '../ProductList';
import { Result } from '../../common/Result';

@Injectable({
  providedIn: 'root',
})
export class OrderDetailService
  extends BaseService<OrderList> {

  constructor(
    http: HttpClient) {
    super(http);

  }

  get(orderId: number): Observable<any> {
    var url = this.getUrl("api/Order_Details/" + orderId);
    return this.http.get<OrderList[]>(url);
  }

  getProduct(): Observable<any> {
    var url = this.getUrl("api/Products/GetProducts");
    return this.http.get(url);
  }

  put(item: OrderList): Observable<Result<OrderList>> {
    var url = this.getUrl("api/Order_Details");
    return this.http.put<Result<OrderList>>(url, item);
  }

  post(item: OrderList, orderId: number): Observable<Result<OrderList>> {
    var url = this.getUrl("api/Order_Details/" + orderId);
    return this.http.post<Result<OrderList>>(url, item);
  }

  delete(item: OrderList): Observable<Result<OrderList>> {
    var url = this.getUrl("api/Order_Details/" + item.orderID + "/" + item.productID);
    return this.http.delete<Result<OrderList>>(url);
  }

}
