import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminProductRoutinModule } from './admin-product-shell/admin-product-routing.module';
import { AdminProductListComponent } from './features/admin-product-list/admin-product-list.component';
import { AdminProductDetailComponent } from './features/admin-product-detail/admin-product-detail.component';
import { SharedModule } from "../../../shared/shared.module";
import { ReactiveFormsModule } from '@angular/forms';
import { AdminProductViewComponent } from './features/admin-product-view/admin-product-view.component';



@NgModule({
  declarations: [
    AdminProductListComponent,
    AdminProductDetailComponent,
    AdminProductViewComponent
  ],
  imports: [
    CommonModule,
    AdminProductRoutinModule,
    SharedModule,
    ReactiveFormsModule
]
})
export class AdminProductModule { }
