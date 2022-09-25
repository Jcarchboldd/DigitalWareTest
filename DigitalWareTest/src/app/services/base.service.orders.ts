import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export abstract class BaseServiceOrders<T> {
  constructor(
    protected http: HttpClient) {
  }

  protected abstract get(orderId: number): any;

  protected getUrl(url: string) {
    return environment.baseUrl + url;
  }
}
