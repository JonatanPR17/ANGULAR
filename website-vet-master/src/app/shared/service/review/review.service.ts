import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ReviewModel } from '../../models/review';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  /* private apiUrl = environment.backEndUrl
  private urlReview = 'reviews' */
  private apiUrl = 'https://localhost:7147';
  private urlReview = 'customers';

  constructor( private httpCliente : HttpClient ) { }

  listAllReviews():Observable<ReviewModel[]>{
    return this.httpCliente.get<ReviewModel[]>(`${this.apiUrl}/${this.urlReview}`)
  }

  getReview(id: number):Observable<ReviewModel>{
    return this.httpCliente.get<ReviewModel>(`${this.apiUrl}/${this.urlReview}/${id}`)
  }

  createReview(data : ReviewModel):Observable<ReviewModel>{
    return this.httpCliente.post<ReviewModel>(`${this.apiUrl}/${this.urlReview}`, data)
  }
  
  updateReview(data: ReviewModel, id : number):Observable<ReviewModel>{
    return this.httpCliente.put<ReviewModel>(`${this.apiUrl}/${this.urlReview}/${id}`,data)
  }

  deleteReview(id: number):Observable<ReviewModel>{
    return this.httpCliente.delete<ReviewModel>(`${this.apiUrl}/${this.urlReview}/${id}`)
  }
}
