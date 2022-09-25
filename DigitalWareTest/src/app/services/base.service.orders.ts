import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

export abstract class BaseServiceOrders<T> {
  constructor(
    protected http: HttpClient) {
  }

  protected abstract get(): any;

  protected getUrl(url: string) {
    return environment.baseUrl + url;
  }
}
