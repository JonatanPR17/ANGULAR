import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CategoryService } from '../../../../../shared/service/category/category.service';
import { CategoryModel } from '../../../../../shared/models/category';

@Component({
  selector: 'app-admin-category-detail',
  templateUrl: './admin-category-detail.component.html',
  styleUrl: './admin-category-detail.component.css'
})
export class AdminCategoryDetailComponent {
  formCategory : FormGroup
  inputData : any

  constructor ( private myform : FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any ,
    private   ref:MatDialogRef <AdminCategoryDetailComponent>,
    private  categoryService : CategoryService
   ) {
    this.formCategory = this.myform.group({
      name: ['',[Validators.required]],
    })
  }

  ngOnInit(): void {
    this.inputData = this.data
  }

  closePopup(){
    this.ref.close()
  }

  submit(data : CategoryModel){
    this.categoryService.createCategory(data).subscribe(
      {
        next: (data) => {
          console.log(data, "Creado bien")
          this.closePopup()
        },
        error : (err) => {
          console.log(err)
        }
      }
    ) 
  }

  editBrand(id: number){
    this.categoryService.updateCategory(id, this.formCategory.value).subscribe(
      {
        next: (data) => {
          this.formCategory.patchValue(data)
          this.closePopup()
        }
      }
    )
  }
}
