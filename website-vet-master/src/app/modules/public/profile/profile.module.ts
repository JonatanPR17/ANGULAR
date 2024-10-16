import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeProfileComponent } from './features/home-profile/home-profile.component';
import { PublicProfielRoutingModule } from './profile-shell/public-profiel-routing.module';
import { SharedModule } from "../../../shared/shared.module";



@NgModule({
  declarations: [
    HomeProfileComponent
  ],
  imports: [
    CommonModule,
    PublicProfielRoutingModule,
    SharedModule
]
})
export class ProfileModule { }
