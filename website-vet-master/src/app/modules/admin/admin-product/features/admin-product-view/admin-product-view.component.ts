import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductServiceModel } from '../../../../../shared/models/productService';
import { ProductServiceService } from '../../../../../shared/service/product-service/product-service.service';

@Component({
  selector: 'app-admin-product-view',
  templateUrl: './admin-product-view.component.html',
  styleUrl: './admin-product-view.component.css'
})
export class AdminProductViewComponent implements OnInit {
  navCont : boolean = true
  hiddenPer : boolean = false

  dataProdSer ?: ProductServiceModel
  imageData: any
  noseNada : [] = [] 

  idAll : number = 0

  

  hidden(){
    this.navCont = !this.navCont
  }
  

  perfil(){
    this.hiddenPer = !this.hiddenPer
  }


  constructor( private _route : ActivatedRoute ,
    private productService: ProductServiceService
   ) {
    
  }

  ngOnInit(): void {
    this._route.params.subscribe( (params )=>{
      this.idAll = parseInt(params['id'])
      const idPS = parseInt(params['id'])     
      this.productService.getProductService(idPS).subscribe(
        {
          next: (data) => {
            this.dataProdSer = data
            console.log(data)
            console.log(data.image)
            this.imageData = data.image
            for (let index = 0; index < this.imageData.length; index++) {
              console.log(this.imageData[index].url)
              console.log(this.noseNada)
              this.noseNada = this.imageData[index].url
            }
          }
        }
      )
    })

  }

}
