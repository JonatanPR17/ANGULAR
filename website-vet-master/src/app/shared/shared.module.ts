import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminNavComponent } from './ui/admin/admin-nav/admin-nav.component';
import { HeaderComponent } from './ui/public/header/header.component';
import { FooterComponent } from './ui/public/footer/footer.component';
import { PanelContactComponent } from './ui/public/panel-contact/panel-contact.component';
import { PanelServiceComponent } from './ui/public/panel-service/panel-service.component';
import { AppRoutingModule } from '../app-routing.module';
import { RouterModule } from '@angular/router';
import { DeleteSuccessfullComponent } from './popup/delete-successfull/delete-successfull.component';
import { CreateSuccessfullComponent } from './popup/create-successfull/create-successfull.component';
import { EditSuccessfullComponent } from './popup/edit-successfull/edit-successfull.component';
import { ConfirmationDeleteComponent } from './popup/confirmation-delete/confirmation-delete.component';
import { PanelProductComponent } from './ui/public/panel-product/panel-product.component';
import { RegisterSuccessfullComponent } from './popup/register-successfull/register-successfull.component';
import { LoginSuccessfullComponent } from './popup/login-successfull/login-successfull.component';
import { LoginErrorComponent } from './popup/login-error/login-error.component';
import { RegisterErrorComponent } from './popup/register-error/register-error.component';
import { LoginOutComponent } from './popup/login-out/login-out.component';



@NgModule({
  declarations: [
    AdminNavComponent,
    HeaderComponent,
    FooterComponent,
    PanelContactComponent,
    PanelServiceComponent,
    DeleteSuccessfullComponent,
    CreateSuccessfullComponent,
    EditSuccessfullComponent,
    ConfirmationDeleteComponent,
    PanelProductComponent,
    RegisterSuccessfullComponent,
    LoginSuccessfullComponent,
    LoginErrorComponent,
    RegisterErrorComponent,
    LoginOutComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    PanelContactComponent,
    PanelServiceComponent,
    PanelProductComponent,
    AdminNavComponent,
    DeleteSuccessfullComponent,
    CreateSuccessfullComponent,
    EditSuccessfullComponent,
    ConfirmationDeleteComponent,
    RegisterSuccessfullComponent,
    LoginErrorComponent,
    LoginSuccessfullComponent,
    RegisterErrorComponent,
    LoginOutComponent
  ]
})
export class SharedModule { }
