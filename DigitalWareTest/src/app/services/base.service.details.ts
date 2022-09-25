import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Result } from '../common/Result';
import { OrderList } from '../order-detail/Model/OrderList';

export abstract class BaseService<T> {
  constructor(
    protected http: HttpClient) {
  }

  protected abstract get(orderId: number):any;
  protected abstract put(item: T): Observable<Result<OrderList>>;
  protected abstract post(item: T, orderId: number): Observable<Result<OrderList>>;
  protected abstract delete(item: T): Observable<Result<OrderList>>;

  protected abstract getProduct(): any;

  protected getUrl(url: string) {
    return environment.baseUrl + url;
  }
}
