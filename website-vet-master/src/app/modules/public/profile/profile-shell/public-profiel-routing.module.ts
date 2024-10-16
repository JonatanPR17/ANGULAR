import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeProfileComponent } from '../features/home-profile/home-profile.component';

const routes: Routes = [
  {
    path: '',
    component: HomeProfileComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublicProfielRoutingModule { }
