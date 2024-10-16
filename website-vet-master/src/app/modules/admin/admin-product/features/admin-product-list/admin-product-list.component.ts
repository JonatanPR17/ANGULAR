import { Component, OnInit } from '@angular/core';
import { ProductServiceModel } from '../../../../../shared/models/productService';
import { ProductServiceService } from '../../../../../shared/service/product-service/product-service.service';
import { MatDialog } from '@angular/material/dialog';
import { AdminProductDetailComponent } from '../admin-product-detail/admin-product-detail.component';
import { Dialog } from '@angular/cdk/dialog';
import { DeleteSuccessfullComponent } from '../../../../../shared/popup/delete-successfull/delete-successfull.component';
import { ConfirmationDeleteComponent } from '../../../../../shared/popup/confirmation-delete/confirmation-delete.component';
import { BrandService } from '../../../../../shared/service/brand/brand.service';
import { BrandModel } from '../../../../../shared/models/brand';
import { CategoryService } from '../../../../../shared/service/category/category.service';
import { CategoryModel } from '../../../../../shared/models/category';
import { AdminBrandDetailComponent } from '../../../admin-brand/features/admin-brand-detail/admin-brand-detail.component';

@Component({
  selector: 'app-admin-product-list',
  templateUrl: './admin-product-list.component.html',
  styleUrl: './admin-product-list.component.css'
})
export class AdminProductListComponent implements OnInit {
  /* navCont : boolean = true

  hidden(){
    this.navCont = !this.navCont
  }

  hiddenPer : boolean = false

  perfil(){
    this.hiddenPer = !this.hiddenPer
  }

  dataProducts : ProductServiceModel[] = []

  constructor( private productService : ProductServiceService,
    private dialog : MatDialog
   ){}

  ngOnInit(): void {
    this.listProducts()
  }

  listProducts(){
    this.productService.listAllProductServices().subscribe(
      {
        next: (data: ProductServiceModel[]) =>{
          this.dataProducts= data
        },
        error: (err) => {
          console.log(err)
        }
      },
    )
  }

  newRegistration(){
    var _popup = this.dialog.open(AdminProductDetailComponent,{
      width: '50%',
      height: '50%',
      data: {
        title : 'Formulario de Productos'
      }
    })
    _popup.afterClosed().subscribe( item => {
      this.listProducts()
    }
    )
  }


  deleteProductService(id: number){
    this.productService.deleteProductService(id).subscribe(
      {
        next: (data) => {
          this.listProducts()
        }
      }
    )
  } */

  navCont : boolean = true
  hiddenPer : boolean = false
  brandList: BrandModel[] = []
  categoryList: CategoryModel[] = []
  productList : ProductServiceModel[] = []

  constructor( private ProSer : ProductServiceService,
    private dialog : MatDialog,
    private brandSer : BrandService,
    private categorySer : CategoryService
   ){}

  hidden(){
    this.navCont = !this.navCont
  }
  

  perfil(){
    this.hiddenPer = !this.hiddenPer
  }

  ngOnInit(): void {
    this.getAllList();
    this.getAllListBrand();
    this.getAllListCategory();
  }


  getAllList(){
    this.ProSer.listAllProductServices().subscribe(
      {
        next: (data)=> {
          this.productList = data
        },
        error :(err) => {
          
        } 
      }
    )
  }

  getAllListBrand(){
    this.brandSer.listAllBrands().subscribe(
      {
        next: (data) => {
          this.brandList = data
        }
      }
    )
  }

  getAllListCategory(){
    this.categorySer.listAllCategories().subscribe(
      {
        next: (data) => {
          this.categoryList = data
        }
      }
    )
  }

  deleteProdSer(id: number){
    this.ProSer.deleteProductService(id).subscribe(
      {
        next: (data) => {
          /* var _popupDelete = this.dialog.open(ConfirmationDeleteComponent,{
            width: '450px',
            height: '350px',
            data: {
            }
          }) */
         var _popupDelete = this.dialog.open(DeleteSuccessfullComponent,{
            width: '450px',
            height: '350px',
         })
         setTimeout(() => {
            _popupDelete.close();
            this.getAllList();
         }, 2000);
        }
      }
    )
  }

  newRegister(id?: any){
    var _popup = this.dialog.open(AdminProductDetailComponent,{
      width: '50%',
      height: '70%',
      data: {
        title: 'Nuevo producto o servicio',
        edit: 'Editar producto o servicio',
        valueId: id
      }
    })
    _popup.afterClosed().subscribe( item => {
      this.getAllList();
    })
  }

  updateProdSer(id:number){
    this.newRegister(id)
  }

  newRegisterBrand(){
    var _popupBrand = this.dialog.open(AdminBrandDetailComponent, {
      width: '30%',
      height: '50%',
      data: {

      }
    })
  }

}
