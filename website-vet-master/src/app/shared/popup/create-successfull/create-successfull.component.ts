import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-create-successfull',
  templateUrl: './create-successfull.component.html',
  styleUrl: './create-successfull.component.css'
})
export class CreateSuccessfullComponent implements OnInit{

  inputData : any

  constructor( @Inject(MAT_DIALOG_DATA) public data: any ,  ){}

  ngOnInit(): void {
    this.inputData = this.data
  }

}
