import { EventEmitter, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomerModel } from '../models/customer.model';
import { CustomerType } from '../models/customerType.model';


@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  newCustomerAdded = new EventEmitter<CustomerModel>();

  constructor(private httpClient: HttpClient) { }

  public GetCustomersTypes(): Observable<CustomerType[]> {
    return this.httpClient.get<CustomerType[]>('http://localhost:63235/customer/types');
  }

  public GetCustomers(): Observable<CustomerModel[]> {
    return this.httpClient.get<CustomerModel[]>('http://localhost:63235/customer');
  }

  public GetCustomer(customerId: number): Observable<CustomerModel> {
    return this.httpClient.get<CustomerModel>(`http://localhost:63235/customer/${customerId}`);
  }

  public CreateCustomer(customer: CustomerModel): Promise<object> {
    return this.httpClient.post('http://localhost:63235/customer', customer).toPromise();
  }
}
