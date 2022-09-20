import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Order } from './Order';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public orders: any = {};

  constructor(private httpClient: HttpClient) {
    this.httpClient.get<Order[]>(environment.baseUrl + 'api/Orders')
      .subscribe(result => {
        this.orders = result;
      }, error => console.error(error));
  }

 
}


