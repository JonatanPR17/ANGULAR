import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegisterModel } from '../../../../shared/models/register';
import { RegisterService } from '../../../../shared/service/register/register.service';
import { ErrorServiceService } from '../../../../shared/ui/errors/error-service.service';
import { MatDialog } from '@angular/material/dialog';
import { RegisterSuccessfullComponent } from '../../../../shared/popup/register-successfull/register-successfull.component';
import { Router } from '@angular/router';
import { StateEnum } from '../../../../shared/models/state.enum';

@Component({
  selector: 'app-sing-up',
  templateUrl: './sing-up.component.html',
  styleUrl: './sing-up.component.css'
})
export class SingUpComponent {
  stateEnum = StateEnum;
  registerState : StateEnum = StateEnum.none
  SignUpForms : FormGroup

  constructor ( private myForm : FormBuilder,
    private registerService : RegisterService,
    private validForm : ErrorServiceService,
    private dialog : MatDialog,
    private router : Router
   ) {
    this.SignUpForms = this.myForm.group({
      name : ['',[Validators.required,Validators.minLength(2),Validators.maxLength(30)]],
      lastName :['',[Validators.required,Validators.minLength(2),Validators.maxLength(30)]],
      mail : ['',[Validators.required,Validators.email]],
      password : ['',[Validators.required,Validators.minLength(6),Validators.maxLength(20)/* ,Validators.pattern('^(?=.*[A-Za-z])(?=.*\d)$') */]],
      repassword : ['',[Validators.required,Validators.minLength(6),Validators.maxLength(20)]]
    })
  }

  onSubmit(register : RegisterModel){
    this.registerState = StateEnum.loading;
    console.log(this.SignUpForms.value)
    this.registerService.newRegister(register).subscribe(
      {
        next: (data) => {
          this.registerState = StateEnum.done;
          console.log(data)
        },
        error: (err)=>{
          this.registerState = StateEnum.error;
        }
      }
    )
  }


  getError(data: string){
    const verific = this.SignUpForms.get(data)
    if (verific && verific?.touched){
      return this.validForm.checkErrors(verific,data)
    } return null
  }


  newMessageSuccesfull(){
    var _popup = this.dialog.open(RegisterSuccessfullComponent,{
      width: '30%',
      height: '40%',
      data: {

      }
    })
    setTimeout(() => {
      _popup.close()
      this.router.navigate(['/auth/sign-in'])
    }, 2000);
  }
  
}
