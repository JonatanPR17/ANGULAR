import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrl: './admin-home.component.css'
})
export class AdminHomeComponent {
  navCont : boolean = true

  hidden(){
    this.navCont = !this.navCont
  }

  hiddenPer : boolean = false

  perfil(){
    this.hiddenPer = !this.hiddenPer
  }
}
