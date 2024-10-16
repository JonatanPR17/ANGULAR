import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdminHomeComponent } from "../admin-home/admin-home.component";

const routes : Routes = [
    {
        path: '',
        component: AdminHomeComponent
    },
    {
        path: '',
        loadChildren: () => import('../admin-product/admin-product.module').then(ap=>ap.AdminProductModule)
    },
    {
        path: '',
        loadChildren : () => import('../admin-brand/admin-brand.module').then(ab=>ab.AdminBrandModule)
    },
    {
        path: '',
        loadChildren: () => import('../admin-category/admin-category.module').then(ac=>ac.AdminCategoryModule)
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AdminRoutingModule { }