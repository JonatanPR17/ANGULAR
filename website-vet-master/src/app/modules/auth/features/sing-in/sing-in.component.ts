import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ErrorServiceService } from '../../../../shared/ui/errors/error-service.service';
import { LoginService } from '../../../../shared/service/login/login.service';
import { LoginModel } from '../../../../shared/models/login';
import { StateEnum } from '../../../../shared/models/state.enum';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { LoginSuccessfullComponent } from '../../../../shared/popup/login-successfull/login-successfull.component';
import { LoginErrorComponent } from '../../../../shared/popup/login-error/login-error.component';

@Component({
  selector: 'app-sing-in',
  templateUrl: './sing-in.component.html',
  styleUrl: './sing-in.component.css'
})
export class SingInComponent {

  stateEnum = StateEnum;
  registerState : StateEnum = StateEnum.none
  SignInForms : FormGroup;

  constructor ( private myForm: FormBuilder,
    private validForm : ErrorServiceService,
    private loginService : LoginService,
    private router : Router,
    private dialog : MatDialog
   ) {
    this.SignInForms = this.myForm.group({
      mail: ['', [Validators.required,Validators.email,Validators.minLength(2),Validators.maxLength(30)]],
      password: ['', [Validators.required,Validators.minLength(6),Validators.maxLength(30)]],
    })
  }

  onSubmit(data: LoginModel){
    this.registerState = this.stateEnum.loading
    this.loginService.login(data).subscribe(
      {
        next: (data) => {
          this.registerState = this.stateEnum.done
          console.log(data);
          if(data.profile.rol.name == 'Administrador' ){
            this.router.navigate(['/admin'])
          } else if(data.profile.rol.name == 'Vendedor' ){
            this.router.navigate(['/admin'])
          } 
          else{
            this.router.navigate([''])
          }
          const _popup = this.dialog.open(LoginSuccessfullComponent,{
            width: '30%',
            height:'50%',
            data: {

            }
          })
          setTimeout(() => {
            _popup.close()
          }, 3000);
        },
        
        error : (err) => {
          console.log(err);
          this.registerState = this.stateEnum.error

          const _popup = this.dialog.open(LoginErrorComponent,{
            width: '30%',
            height: '50%',
            data: {

            }
          })
          setTimeout(() => {
            _popup.close()
          }, 3000);
        }

      }
    )
  }

  getError(data: string){
    const verific = this.SignInForms.get(data)
    if (verific && verific?.touched){
      return this.validForm.checkErrors(verific,data)
    } return null
  }

}
