import { Component, OnDestroy, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit, OnDestroy {
  textHidden : boolean = false;
  hiddenButton : boolean = true;

  listImage : string[] = [
    './image/image1.png',
    './image/image2.png',
  ]

  imageContent ?: string
  imageInterval ?: any


  hiddenText(){
    this.textHidden = true;
    this.hiddenButton = false;
  }

  lessText(){
    this.textHidden = false;
    this.hiddenButton = true;
  }

  ngOnInit(): void {
    this.changeImage()
  }

  ngOnDestroy(): void {
    if(this.imageInterval){
      clearInterval(this.imageInterval)
      console.log('delete component')
    }
  }
  
  num : number = 1

  changeImage(){

    /* this.imageInterval = setInterval(() => {
      this.num ++
      const indexImage = this.num % this.listImage.length
      this.imageContent= this.listImage[indexImage]
      console.log(this.imageContent)
    }, 2000); */
  }

}
