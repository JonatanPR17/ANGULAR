import { Component, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BrandModel } from '../../../../../shared/models/brand';
import { BrandService } from '../../../../../shared/service/brand/brand.service';
import { AdminProductListComponent } from '../../../admin-product/features/admin-product-list/admin-product-list.component';


@Component({
  selector: 'app-admin-brand-detail',
  templateUrl: './admin-brand-detail.component.html',
  styleUrl: './admin-brand-detail.component.css'
})
export class AdminBrandDetailComponent {
  formBrand : FormGroup
  inputData : any

  constructor ( private myform : FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any ,
    private   ref:MatDialogRef <AdminProductListComponent>,
    private  brandService : BrandService
   ) {
    this.formBrand = this.myform.group({
      name: ['',[Validators.required]],
    })
  }

  ngOnInit(): void {
    this.inputData = this.data
  }

  closePopup(){
    this.ref.close()
  }

  submit(data : BrandModel){
    this.brandService.createBrand(data).subscribe(
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
    this.brandService.updateBrand(id, this.formBrand.value).subscribe(
      {
        next: (data) => {
          this.formBrand.patchValue(data)
          this.closePopup()
        }
      }
    )
  }
}
