import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminCategoryListComponent } from './features/admin-category-list/admin-category-list.component';
import { AdminCategoryRoutingModule } from './admin-category-shell/admin-category-routing.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AdminCategoryListComponent,

  ],
  imports: [
    CommonModule,
    AdminCategoryRoutingModule,
    ReactiveFormsModule
  ]
})
export class AdminCategoryModule { }
