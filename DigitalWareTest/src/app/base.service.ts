import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

export abstract class BaseService<T> {
  constructor(
    protected http: HttpClient) {
  }

  protected abstract get(orderId: number):any;
  protected abstract put(item: T, orderId: number): Observable<T>;
  protected abstract post(item: T, orderId: number): Observable<T>;
  protected abstract delete(orderId: number, productId: number): Observable<T>;

  protected abstract getProduct(): any;

  protected getUrl(url: string) {
    return environment.baseUrl + url;
  }
}
