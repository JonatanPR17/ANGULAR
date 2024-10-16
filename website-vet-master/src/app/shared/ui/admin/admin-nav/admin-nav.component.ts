import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-nav',
  templateUrl: './admin-nav.component.html',
  styleUrl: './admin-nav.component.css'
})
export class AdminNavComponent {
  navAdmin : boolean = true

  hiddenNav(){
    this.navAdmin = !this.navAdmin
  }

  listHidden: boolean = false

  list(){
    this.listHidden = !this.listHidden
  }

}
