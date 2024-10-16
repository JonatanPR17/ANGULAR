import { NgModule } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { ServiceComponent } from './service/service.component';
import { ReviewComponent } from './review/review.component';
import { PublicRoutingModule } from './public-shell/public-routing.module';
import { SharedModule } from "../../shared/shared.module";



@NgModule({
  declarations: [
    HomeComponent,
    ServiceComponent,
    ReviewComponent
  ],
  imports: [
    CommonModule,
    PublicRoutingModule,
    SharedModule,
    NgOptimizedImage
]
})
export class PublicModule { }
