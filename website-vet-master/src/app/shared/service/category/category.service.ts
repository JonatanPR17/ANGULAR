import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CategoryModel } from '../../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  /* private apiUrl = environment.backEndUrl
  private urlCategory = 'categories' */
  private apiUrl = 'https://localhost:7180';
  private urlCategory = 'api/store/categories';

  constructor(private httpClient : HttpClient) { }

  listAllCategories():Observable<CategoryModel[]>{
    return this.httpClient.get<CategoryModel[]>(`${this.apiUrl}/${this.urlCategory}`)
  }

  getCategory(id:number):Observable<CategoryModel>{
    return this.httpClient.get<CategoryModel>(`${this.apiUrl}/${this.urlCategory}/${id}`)
  }

  createCategory(data: CategoryModel):Observable<CategoryModel>{
    return this.httpClient.post<CategoryModel>(`${this.apiUrl}/${this.urlCategory}`,data)
  }

  updateCategory(id:number, data:CategoryModel):Observable<CategoryModel>{
    return this.httpClient.put<CategoryModel>(`${this.apiUrl}/${this.urlCategory}/${id}`,data)
  }

  deleteCategory(id:number):Observable<CategoryModel>{
    return this.httpClient.delete<CategoryModel>(`${this.apiUrl}/${this.urlCategory}/${id}`)
  }
}
