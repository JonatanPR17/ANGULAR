import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { SingInComponent } from "../features/sing-in/sing-in.component";
import { SingUpComponent } from "../features/sing-up/sing-up.component";

const routes : Routes = [
    {
        path : 'sign-in',
        component : SingInComponent
    },
    {
        path: 'sign-up',
        component : SingUpComponent
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class AuthRoutingModule { }