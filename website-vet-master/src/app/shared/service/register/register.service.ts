import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterModel } from '../../models/register';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  private apiUrl = 'https://localhost:7180';
  private urlRegister = 'api/auth/authentication/register';
  
  constructor(private httpCliente : HttpClient ) { }

  newRegister(data : RegisterModel):Observable<RegisterModel>{
    return this.httpCliente.post<RegisterModel>(`${this.apiUrl}/${this.urlRegister}`, data)
  }

}
