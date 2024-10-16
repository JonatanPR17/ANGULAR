import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SaleDetailModel } from '../../models/sale-detail';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SaleDetailService {

  /* private apiUrl = environment.backEndUrl
  private urlSaleDetail = 'reviews' */
  private apiUrl = 'https://localhost:7147';
  private urlSaleDetail = 'customers';

  constructor( private httpCliente : HttpClient ) { }

  listAllSaleDetails():Observable<SaleDetailModel[]>{
    return this.httpCliente.get<SaleDetailModel[]>(`${this.apiUrl}/${this.urlSaleDetail}`)
  }

  getSaleDetail(id: number):Observable<SaleDetailModel>{
    return this.httpCliente.get<SaleDetailModel>(`${this.apiUrl}/${this.urlSaleDetail}/${id}`)
  }

  createSaleDetail(data : SaleDetailModel):Observable<SaleDetailModel>{
    return this.httpCliente.post<SaleDetailModel>(`${this.apiUrl}/${this.urlSaleDetail}`, data)
  }
  
  updateSaleDetail(data: SaleDetailModel, id : number):Observable<SaleDetailModel>{
    return this.httpCliente.put<SaleDetailModel>(`${this.apiUrl}/${this.urlSaleDetail}/${id}`,data)
  }

  deleteSaleDetail(id: number):Observable<SaleDetailModel>{
    return this.httpCliente.delete<SaleDetailModel>(`${this.apiUrl}/${this.urlSaleDetail}/${id}`)
  }
}
