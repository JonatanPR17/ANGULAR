import { Component, OnInit } from '@angular/core';
import { ProductServiceModel } from '../../../models/productService';
import { ProductServiceService } from '../../../service/product-service/product-service.service';

@Component({
  selector: 'app-panel-product',
  templateUrl: './panel-product.component.html',
  styleUrl: './panel-product.component.css'
})
export class PanelProductComponent implements OnInit {


  listProduct : ProductServiceModel[] = []
  anyProduct: ProductServiceModel | any


  constructor ( private productService : ProductServiceService ) {
    
  }

  ngOnInit(): void {
    this.getAllListProduct();
  }

  getAllListProduct(){
    this.productService.getListAllProduct().subscribe(
      {
        next: (data) => {
          this.listProduct = data
          this.anyProduct = this.listProduct.slice(0,6)
          console.log(this.listProduct)
          console.log(this.anyProduct)
        }
      }
    )
  }

  



}
