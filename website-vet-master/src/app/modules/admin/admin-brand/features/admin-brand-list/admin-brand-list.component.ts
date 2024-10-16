import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-brand-list',
  templateUrl: './admin-brand-list.component.html',
  styleUrl: './admin-brand-list.component.css'
})
export class AdminBrandListComponent {
  navCont : boolean = true
  
  hiddenPer : boolean = false

  hidden(){
    this.navCont = !this.navCont
  }
  

  perfil(){
    this.hiddenPer = !this.hiddenPer
  }

}
