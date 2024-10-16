import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductServiceModel } from '../../models/productService';


@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {

  /* private apiUrl = environmentUrl.backEndUrl */
  private apiUrl = 'https://localhost:7180';
  private urlProductService = 'api/store/products_services';

  constructor( private httpCliente : HttpClient ) { 
    /* console.log(this.apiUrl) */
  }

  listAllProductServices():Observable<ProductServiceModel[]>{
    return this.httpCliente.get<ProductServiceModel[]>(`${this.apiUrl}/${this.urlProductService}`)
  }

  getProductService(id: number):Observable<ProductServiceModel>{
    return this.httpCliente.get<ProductServiceModel>(`${this.apiUrl}/${this.urlProductService}/join/${id}`)
  }
  
  getListAllService():Observable<ProductServiceModel[]>{
    return this.httpCliente.get<ProductServiceModel[]>(`https://localhost:7180/api/store/products_services/only_service`)
  }

  getListAllProduct():Observable<ProductServiceModel[]>{
    return this.httpCliente.get<ProductServiceModel[]>(`https://localhost:7180/api/store/products_services/only_products`)
  }

  createProductService(data : ProductServiceModel):Observable<ProductServiceModel>{
    return this.httpCliente.post<ProductServiceModel>(`${this.apiUrl}/${this.urlProductService}`, data)
  }
  
  updateProductService(data: ProductServiceModel, id : number):Observable<ProductServiceModel>{
    return this.httpCliente.put<ProductServiceModel>(`${this.apiUrl}/${this.urlProductService}/${id}`,data)
  }

  deleteProductService(id: number):Observable<ProductServiceModel>{
    return this.httpCliente.delete<ProductServiceModel>(`${this.apiUrl}/${this.urlProductService}/${id}`)
  }
}
