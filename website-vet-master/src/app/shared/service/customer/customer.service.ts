import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerModel } from '../../models/customer';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  /* private apiUrl = environment.backEndUrl
  private urlCustomer = 'customers' */
  private apiUrl = 'https://localhost:7180';
  private urlCustomer = 'customers';

  constructor(private httpClient : HttpClient) { }

  listAllCustomers():Observable<CustomerModel[]>{
    return this.httpClient.get<CustomerModel[]>(`${this.apiUrl}/${this.urlCustomer}`)
  }

  getCustomer(id:number):Observable<CustomerModel>{
    return this.httpClient.get<CustomerModel>(`${this.apiUrl}/${this.urlCustomer}/${id}`)
  }

  createCustomer(data: CustomerModel):Observable<CustomerModel>{
    return this.httpClient.post<CustomerModel>(`${this.apiUrl}/${this.urlCustomer}`,data)
  }

  updateCustomer(id:number, data:CustomerModel):Observable<CustomerModel>{
    return this.httpClient.put<CustomerModel>(`${this.apiUrl}/${this.urlCustomer}/${id}`,data)
  }

  deleteCustomer(id:number):Observable<CustomerModel>{
    return this.httpClient.delete<CustomerModel>(`${this.apiUrl}/${this.urlCustomer}/${id}`)
  }
}
