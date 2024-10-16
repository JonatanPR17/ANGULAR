import { Component } from '@angular/core';

@Component({
  selector: 'app-panel-contact',
  templateUrl: './panel-contact.component.html',
  styleUrl: './panel-contact.component.css'
})
export class PanelContactComponent {
  info1 : boolean = false  
  info2 : boolean = false
  info3 : boolean = false


  hiddenInfo(indiceDiv: number){
    if (indiceDiv===1) {
      this.info1 = !this.info1
      this.info2 = false
      this.info3 = false
    } else if (indiceDiv===2){
      this.info2 = !this.info2
      this.info1 = false
      this.info3 = false
    } else if (indiceDiv===3){
      this.info3 = !this.info3
      this.info1 = false
      this.info2 = false
    }
  }
}
