import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseServiceOrders } from '../../services/base.service.orders';

import { Order } from '../Model/Order';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class OrderService
  extends BaseServiceOrders<Order> {

  constructor(
    http: HttpClient) {
    super(http);

  }

  get(): Observable<any> {
    var url = this.getUrl("api/Orders/GetOrders");
    return this.http.get(url);
  }
}


