import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "../home/home.component";
import { ServiceComponent } from "../service/service.component";
import { ReviewComponent } from "../review/review.component";

const routes : Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'services',
        component: ServiceComponent
    },
    {
        path: 'reviews',
        component: ReviewComponent
    },
    {
        path: 'product',
        loadChildren: () => import('../product/product.module').then(p=>p.ProductModule)
    },
    {
        path: 'profile',
        loadChildren: () => import('../profile/profile.module').then(p=>p.ProfileModule)
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class PublicRoutingModule { }