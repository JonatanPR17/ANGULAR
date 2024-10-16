import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminBrandListComponent } from './features/admin-brand-list/admin-brand-list.component';
import { AdminBrandDetailComponent } from './features/admin-brand-detail/admin-brand-detail.component';
import { AdminBrandRoutingModule } from './admin-brand-shell/admin-brand-routing.module';
import { SharedModule } from "../../../shared/shared.module";
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AdminBrandListComponent,
    AdminBrandDetailComponent
  ],
  imports: [
    CommonModule,
    AdminBrandRoutingModule,
    SharedModule,
    ReactiveFormsModule
]
})
export class AdminBrandModule { }
