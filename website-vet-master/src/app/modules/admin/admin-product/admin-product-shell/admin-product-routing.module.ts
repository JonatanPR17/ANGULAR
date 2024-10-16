import { NgModule } from "@angular/core";
import { Route, RouterModule, Routes } from "@angular/router";
import { AdminProductListComponent } from "../features/admin-product-list/admin-product-list.component";
import { AdminProductDetailComponent } from "../features/admin-product-detail/admin-product-detail.component";
import { AdminProductViewComponent } from "../features/admin-product-view/admin-product-view.component";

const routes : Routes = [
    {
        path: 'products',
        component: AdminProductListComponent
    },
    {
        path: 'productService/:id',
        component: AdminProductViewComponent
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AdminProductRoutinModule { }