import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { ProizvodiComponent } from './proizvodi/proizvodi.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {RouterModule} from "@angular/router";
import { SignUpComponent } from './sign-up/sign-up.component';
import { PocetnaKupacComponent } from './pocetna-kupac/pocetna-kupac.component';
import {AuthGuard} from "./guards/auth.guard";
import {TokenInterceptor} from "./interceptors/token.interceptor";
import { OnamaComponent } from './onama/onama.component';
import { PregledProizvodaComponent } from './pregled-proizvoda/pregled-proizvoda.component';
import * as path from "path";
import { ServisiComponent } from './servisi/servisi.component';
import { OtvoriProizvodeComponent } from './otvori-proizvode/otvori-proizvode.component';
import { NavbarKupacComponent } from './navbar-kupac/navbar-kupac.component';
import { NavbarUposlenikComponent } from './navbar-uposlenik/navbar-uposlenik.component';
import { FooterComponent } from './footer/footer.component';
import { ServisiKupacComponent } from './servisi-kupac/servisi-kupac.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ProizvodiComponent,
    SignUpComponent,
    PocetnaKupacComponent,
    OnamaComponent,
    PregledProizvodaComponent,
    ServisiComponent,
    OtvoriProizvodeComponent,
    NavbarKupacComponent,
    NavbarUposlenikComponent,
    FooterComponent,
    ServisiKupacComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {path: '', redirectTo:'login', pathMatch:'full'},
      {path: 'login', component:LoginComponent},
      {path:'pocetna-kupac',component:PocetnaKupacComponent, canActivate:[AuthGuard]},
      {path: 'proizvodi', component: ProizvodiComponent, canActivate:[AuthGuard]},
      {path: 'sign-up', component: SignUpComponent, canActivate:[AuthGuard]},
      {path: 'onama', component: OnamaComponent, canActivate:[AuthGuard]},
      {path: 'pregled-proizvoda', component: PregledProizvodaComponent, canActivate:[AuthGuard]},
      {path: 'servisi', component: ServisiComponent, canActivate:[AuthGuard]},
      {path: 'otvori-proizvode/:id', component: OtvoriProizvodeComponent, canActivate:[AuthGuard]},
      {path:'navbar-kupac',component:NavbarKupacComponent, canActivate:[AuthGuard]},
      {path:'navbar-uposlenik',component:NavbarUposlenikComponent, canActivate:[AuthGuard]},
      {path:'footer',component:FooterComponent, canActivate:[AuthGuard]},
      {path:'servisi-kupac',component:ServisiKupacComponent, canActivate:[AuthGuard]}
    ]),
  ],
  providers: [{
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptor,
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
