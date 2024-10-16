import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { SharedModule } from "../../shared/shared.module";
import { AdminRoutingModule } from './admin-shell/admin-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';





@NgModule({
  declarations: [
    AdminHomeComponent,
    /* AdminCategoryDetailComponent,
    AdminCategoryListComponent */
  ],
  imports: [
    CommonModule,
    SharedModule,
    AdminRoutingModule,
    ReactiveFormsModule,
    RouterOutlet
  ]
})
export class AdminModule { }
