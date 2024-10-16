import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BrandModel } from '../../models/brand';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  /* private apiUrl = environment.backEndUrl
  private urlBrand = 'brands' */
  /* private apiUrl = environmentUrl.backEndUrl */
  private apiUrl = 'https://localhost:7180';
  private urlBrand = 'api/store/brands';

  constructor( private httpCliente : HttpClient ) { }

  listAllBrands():Observable<BrandModel[]>{
    return this.httpCliente.get<BrandModel[]>(`${this.apiUrl}/${this.urlBrand}`)
  }

  getBrand(id : number):Observable<BrandModel>{
    return this.httpCliente.get<BrandModel>(`${this.apiUrl}/${this.urlBrand}/${id}`)
  }

  createBrand(data: BrandModel):Observable<BrandModel>{
    return this.httpCliente.post<BrandModel>(`${this.apiUrl}/${this.urlBrand}`,data)
  }

  updateBrand(id: number, data: BrandModel):Observable<BrandModel>{
    return this.httpCliente.put<BrandModel>(`${this.apiUrl}/${this.urlBrand}/${id}`,data)
  }

  deleteBrand(id: number):Observable<BrandModel>{
    return this.httpCliente.delete<BrandModel>(`${this.apiUrl}/${this.urlBrand}/${id}`)
  }
}
