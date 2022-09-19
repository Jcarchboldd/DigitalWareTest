import { Component, Input, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { OrderList } from './OrderList';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css']
})
export class OrderDetailComponent implements AfterViewInit {
  @Input() key!: number;
  public ordersDetails: any = {};

  constructor(private httpClient: HttpClient) {
    
  }

  ngAfterViewInit() {
    this.httpClient.get<OrderList[]>(environment.baseUrl + 'api/Order_Details')
      .subscribe(result => {
        this.ordersDetails = result.filter((obj) => {
          return obj.orderID === this.key;
        });
      }, error => console.error(error));

  }

}
