import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BrandModel } from '../../../../../shared/models/brand';
import { CategoryModel } from '../../../../../shared/models/category';
import { BrandService } from '../../../../../shared/service/brand/brand.service';
import { CategoryService } from '../../../../../shared/service/category/category.service';
import { ProductServiceService } from '../../../../../shared/service/product-service/product-service.service';
import { ProductServiceModel } from '../../../../../shared/models/productService';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AdminProductListComponent } from '../admin-product-list/admin-product-list.component';
import {  Storage, ref , uploadBytes, listAll, getDownloadURL} from '@angular/fire/storage'
import { CreateSuccessfullComponent } from '../../../../../shared/popup/create-successfull/create-successfull.component';
import { EditSuccessfullComponent } from '../../../../../shared/popup/edit-successfull/edit-successfull.component';


@Component({
  selector: 'app-admin-product-detail',
  templateUrl: './admin-product-detail.component.html',
  styleUrl: './admin-product-detail.component.css'
})
export class AdminProductDetailComponent {

  urlData : string = ''

  formProductService : FormGroup
  inputData : any
  brand : BrandModel[]= []
  category : CategoryModel[]= []
  valueType : string = ''

  constructor ( private myForm : FormBuilder,
    private brandService : BrandService,
    private categoryService : CategoryService,
    private productService : ProductServiceService,
    @Inject(MAT_DIALOG_DATA) public data: any ,
    private   ref:MatDialogRef <AdminProductListComponent>,
    private storage : Storage,
    private dialog : MatDialog

   ) {
    this.formProductService = this.myForm.group({
      name:[''] ,
      type:[''] ,
      description:[''] ,
      price: [0],
      stock :[0] ,
      state: [false],
      image: [''],
      brandId: [7],
      categoryId: [14],

    })
  }

  ngOnInit(): void {
    this.load();
    this.inputData = this.data;
  }

  load(){
    this.brandService.listAllBrands().subscribe(
      {
        next: (nose) => {
          console.log("good")
          this.brand = nose
        }
      }
    ),

    this.categoryService.listAllCategories().subscribe(
      {
        next: (sise) => {
          console.log('WELL')
          this.category = sise
        }
      }
    )
  }

  updateImage($event : any | void ){
    const infoImage = $event.target.files[0]
    console.log(infoImage)
    const refImage = ref(this.storage, `product/${infoImage.name}`)

    uploadBytes(refImage, infoImage)
      .then( async info => {
        console.log(info)

        const url = await getDownloadURL(refImage)
        this.urlData = url
        console.log(this.urlData)
        
      })
      .catch(err => {
        console.log(err)
      })
  }

  /* async getImage (nose : any){
    const refImage = ref(this.storage, `product/${nose.name}`)

    const url = await getDownloadURL(refImage)
    console.log(url)
    return url;

  } */

  /* async submit(product : ProductServiceModel){
    
    const urlImage = this.urlData
    console.log("Estoy en el submit y es ", urlImage)
    
    if (urlImage) {
      product.image =  urlImage
      this.productService.createProductService(product).subscribe(
        {
           next: (nose) => {
             console.log("estoy en el if",urlImage)
            console.log('creado good')
            console.log(product.image)
            console.log(product)
            this.close()
            var _popupCreate = this.dialog.open(CreateSuccessfullComponent,{
              width: '450px',
              height: '350px',
              data: {
                typeService : this.valueType
              }
            })

            setTimeout(() => {
              _popupCreate.close();
            }, 8000);

          }
        }
      )
    }
  } */

  close(){
    this.ref.close()
  }

  nose($event:any){
    const nose = $event.target.value
    this.valueType = nose
  }

  updateRegister(id: number){
    const urlImage = this.urlData
    this.formProductService.value.image = urlImage
    if(urlImage){
      this.productService.updateProductService(this.formProductService.value as ProductServiceModel , id).subscribe(
        {
          next: (info  ) => {
            this.formProductService.patchValue(info);
            this.close();
            var _popupUpdate = this.dialog.open(EditSuccessfullComponent, {
                width: '450px',
                height: '350px',
            }) 
            setTimeout(() => {
              _popupUpdate.close();
            }, 2000);
          }
        }
      )
    }

    
  }

}
