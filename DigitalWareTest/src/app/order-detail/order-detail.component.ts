import { Component, Input, AfterViewInit, OnInit } from '@angular/core';
import CustomStore from 'devextreme/data/custom_store';
import { OrderDetailService } from './Service/order-detail.service';
import { OrderList } from './Model/OrderList';
import { Result } from '../common/Result';
import { ProductList } from './ProductList';


@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css']
})
export class OrderDetailComponent implements AfterViewInit {
  @Input() OrderId!: number;
  ordersDetails: OrderList[] = [];
  dataSource: any;
  productData: any;
  products: any = {};
  message?: string;
  validator: boolean = false;

  refreshModes: string[];
  refreshMode: string;
  requests: string[] = [];

  constructor(private orderDetailService: OrderDetailService) {
    this.refreshMode = 'reshape';
    this.refreshModes = ['full', 'reshape', 'repaint'];

  }

  // Evita modificar el producto con la fila en edición
  onEditorPreparing(e: { dataField: string; row: { isNewRow: boolean; }; editorOptions: { readOnly: boolean; }; }) {
    if (e.dataField == 'productID' && e.row.isNewRow != true) {
      e.editorOptions.readOnly = true;
    }
  }

  ngAfterViewInit() {

    this.refresh();

    this.orderDetailService.getProduct()
      .subscribe((data: Result<ProductList>) => {
        this.products = data.items;
      });

    this.productData = {
      paginate: true,
      store: new CustomStore({
        key: 'Value',
        loadMode: 'raw',
        load: () => this.products,
      }),
    };

  }

  onRowInserted(event: { data: any; }) {
    this.orderDetailService.post(event.data, this.OrderId).subscribe((data: Result<OrderList>) => {
      this.message = data.ResponseMessage;
      this.validator = data.Error;
    });
  }

  onRowUpdated(event: { data: any; }) {
    this.orderDetailService.put(event.data).subscribe((data: Result<OrderList>) => {
      this.message = data.ResponseMessage;
      this.validator = data.Error;
    });
  }

  onRowRemoved(event: { data: any; }) {
    this.orderDetailService.delete(event.data).subscribe((data: Result<OrderList>) => {
      this.message = data.ResponseMessage;
      this.validator = data.Error;
    });
  }

  onSaved(event: { data: any; }) {
    this.refresh();
  }

  private refresh()
  {
    this.ordersDetails = [];

    this.orderDetailService.get(this.OrderId)
      .subscribe((data: Result<OrderList>) => {
        this.ordersDetails = data.items;
      });
  }

}
