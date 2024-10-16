import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-confirmation-delete',
  templateUrl: './confirmation-delete.component.html',
  styleUrl: './confirmation-delete.component.css'
})
export class ConfirmationDeleteComponent implements OnInit {

  constructor( private ref : MatDialogRef <ConfirmationDeleteComponent> ){}

  ngOnInit(): void {
    
  }

  closePopup(){
    this.ref.close();
  }
}
