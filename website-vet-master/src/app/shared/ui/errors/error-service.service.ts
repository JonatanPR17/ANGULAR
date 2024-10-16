import { Injectable } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ErrorServiceService {
  //AbstractControl te trae cualquier control del formulario como touch, etc
  checkErrors(valid:AbstractControl, data:string ){
    if(valid.hasError('required')){
      return `Este campo es requerido `;
    } else if (valid.hasError('minlength')){
      const minRequired = valid.errors?.['minlength'].requiredLength;
      return ` Debe tener al menos ${minRequired} caracteres `
    } else if (valid.hasError('maxlength')){
      const maxRequired = valid.errors?.['maxlength'].requiredLength;
      return `Dede tener maximo ${maxRequired} caracteres`
    } else if (valid.hasError('email')){
      return `Debe tener un formato de correo electronico`
    }else if (valid.hasError('pattern')){
      return `Deber tener al menos un letra mayuscula, numero o caracter especial`
    }
    
    return null;
  }


}
