import { Component, OnInit } from '@angular/core';
import { ProductServiceModel } from '../../../models/productService';
import { ProductServiceService } from '../../../service/product-service/product-service.service';

@Component({
  selector: 'app-panel-service',
  templateUrl: './panel-service.component.html',
  styleUrl: './panel-service.component.css'
})
export class PanelServiceComponent implements OnInit {

  listService : ProductServiceModel[] = []
  specificService : ProductServiceModel | any

  constructor ( private service : ProductServiceService ) {

  }

  ngOnInit(): void {
    this.getAllService()
    this.getService()
  }

  getAllService () {
    this.service.getListAllService().subscribe(
      {
        next: (data) => {
          this.listService = data
        }
      }
    )
  }
  
  getService(int ?: number | any ){
    this.specificService= this.listService.find( valueId => valueId.id = int )
    
  }

}
