import { Component } from '@angular/core';
import { Order } from './Order';
import { Result } from '../common/Result';
import { OrderService } from './order.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public orders: any = {};

  constructor(orderService: OrderService) {

    orderService.get()
      .subscribe((data: Result<Order>) => {
        this.orders = data.items;
      });

  }

 
}


