import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../../../../shared/service/login/login.service';
import { ProfileModel } from '../../../../../shared/models/profile';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-home-profile',
  templateUrl: './home-profile.component.html',
  styleUrls: ['./home-profile.component.css']
})
export class HomeProfileComponent implements OnInit {
  profile?: ProfileModel;

  constructor(private loginService: LoginService, private sanitizer: DomSanitizer) {}

  ngOnInit(): void {
    this.profile = this.loginService.getProfile();
  }

  // Cambiar la foto de perfil
  onProfilePictureChange(event: any): void {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        this.profile!.profilePictureUrl = this.sanitizer.bypassSecurityTrustUrl(reader.result as string) as string;
      };
      reader.readAsDataURL(file);
    }
  }

  // Eliminar la foto de perfil
  deleteProfilePicture(): void {
    this.profile!.profilePictureUrl = '';  // También podrías colocar una imagen predeterminada aquí
  }

  logOut() {
    this.loginService.logOut();
  }
}
