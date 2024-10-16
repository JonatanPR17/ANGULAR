import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginModel, LoginResponse } from '../../models/login';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { ProfileModel } from '../../models/profile';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private profile? : ProfileModel;
  /* Un subjejct es un elemento de orx, que es similar a un observable, permite tener un interfaz libre de datos, es decir podras
  cambiar los datos segun el flujo, lo podras alimentar con datos y stremearlo */
  private profileSubject : BehaviorSubject<ProfileModel | undefined >

  private apiUrl = 'https://localhost:7180';
  private urlLogin = 'api/auth/authentication/login';

  constructor(private httpCliente: HttpClient) { 
    /* Cada vez que actualicemos nos traera esto */
    const profileData = localStorage.getItem('profile')
    if(profileData){
      /* Convierte de caden a Json */
      /* Tambien sirve para reemplazar los datos, que ingresen */
      this.profile = JSON.parse(profileData)
    }
    this.profileSubject = new BehaviorSubject(this.profile)
   }


  /* // en el () ponemos los datos que queremos que nos devuelva, en el observable */
  login(data : LoginModel):Observable<LoginResponse>{
    return this.httpCliente.post<LoginResponse>(`${this.apiUrl}/${this.urlLogin}`, data).pipe(
      /* Estamoss letendo el valor, pipe o tuberia, captura la respuesta antes de devolverla y el tap la lee, map es para modificarla */
      tap((response) => this.proccesLogin(response)
      /* Envio esta informacion a mi funcion procceslogin */
    ))
  }

  getProfile(): ProfileModel | undefined {
    console.log(this.profile)
    return this.profile
  }

  changeProfile(): Observable< ProfileModel | undefined> {
    return this.profileSubject.asObservable();
  }

  setProfile(profile : ProfileModel | undefined){
    this.profile = profile
    this.profileSubject.next(this.profile);
  }

  

  /* //Estamos creando una funcion que esta almacenando el profile en nuestro variable profiile */
  private proccesLogin(res : LoginResponse){
    this.profile = res.profile
    this.profileSubject.next(this.profile)
    /* inyectamos al local storage una llave de clave valor,  */
    localStorage.setItem('jwt',res.token);
    // convierto mi objeto o modelo en una cadena de texto
    localStorage.setItem('profile', JSON.stringify(res.profile) );
  }

  logOut(){
    this.profile = undefined
    localStorage.clear();
    this.profileSubject.next(undefined);
  }

}
