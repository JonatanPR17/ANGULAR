import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { initializeApp, provideFirebaseApp } from '@angular/fire/app';
import { getStorage, provideStorage } from '@angular/fire/storage';
import { SharedModule } from './shared/shared.module';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    MatDialogModule
    
  ],
  providers: [
    provideHttpClient(withFetch()),
    provideAnimationsAsync(),
    provideFirebaseApp(() => initializeApp({"projectId":"website-vet","appId":"1:900139832225:web:828a861557b23645f4b1e0","storageBucket":"website-vet.appspot.com","apiKey":"AIzaSyD1u52pH_7DzDhzQRK4gzNVawSLooFuQlw","authDomain":"website-vet.firebaseapp.com","messagingSenderId":"900139832225"})),
    provideStorage(() => getStorage())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
