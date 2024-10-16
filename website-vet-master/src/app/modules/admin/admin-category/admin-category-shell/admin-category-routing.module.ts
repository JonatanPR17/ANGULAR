import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdminCategoryListComponent } from "../features/admin-category-list/admin-category-list.component";


const routes : Routes = [
    {
        path: 'categories',
        component: AdminCategoryListComponent
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AdminCategoryRoutingModule { }