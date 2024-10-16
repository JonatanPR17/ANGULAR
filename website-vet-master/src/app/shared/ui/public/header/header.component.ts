import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../../service/login/login.service';
import { ProfileModel } from '../../../models/profile';
import { MatDialog } from '@angular/material/dialog';
import { LoginOutComponent } from '../../../popup/login-out/login-out.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {
  
  profile?: ProfileModel
  show : boolean = false

  constructor( private loginService : LoginService,
    private dialog : MatDialog,
    private router : Router
   ){

  }
  ngOnInit(): void {
    //this.profile = this.loginService.getProfile()
    this.loginService.changeProfile().subscribe(
      {
        next: (data) => {
          this.profile = data;
        }
      }
    )
  }

  loginOut(){
    this.loginService.logOut();
    const _popup = this.dialog.open(LoginOutComponent,{
      width: '30%',
      height: '50%',
      data: {

      }
    })
    setTimeout(() => {
      _popup.close()
      this.router.navigate(['']);
    }, 2000);
  }

}
