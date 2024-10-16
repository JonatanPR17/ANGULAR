import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdminBrandListComponent } from "../features/admin-brand-list/admin-brand-list.component";

const routes : Routes = [
    {
        path: 'brands',
        component: AdminBrandListComponent
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AdminBrandRoutingModule { }