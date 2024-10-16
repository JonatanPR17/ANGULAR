import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SingInComponent } from './features/sing-in/sing-in.component';
import { SingUpComponent } from './features/sing-up/sing-up.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthRoutingModule } from './auth-shell/admin-auth-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { RouterOutlet } from '@angular/router';



@NgModule({
  declarations: [
    SingInComponent,
    SingUpComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SharedModule,
    AuthRoutingModule,
    RouterOutlet
  ]
})
export class AuthModule { }
