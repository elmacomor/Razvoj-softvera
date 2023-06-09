import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {JwtHelperService} from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl:string = 'https://localhost:7093/Autentifikacija/';
  private  userPayload:any;
  constructor(private http: HttpClient, private router: Router) {
    this.userPayload = this.decodeToken();
  }

  signUp(userObj:any){
    return this.http.post<any>(`${this.baseUrl}SignUp`,userObj);
  }

  signIn(loginObj:any){
    return this.http.post<any>(`${this.baseUrl}Login`,loginObj);
  }

  storeToken(tokenValue : string){
    localStorage.setItem('token',tokenValue)
  }

  getToken(){
    return localStorage.getItem('token')
  }

  isLoggedIn():boolean{
    return !!localStorage.getItem('token') //pretvara string u bool vrijednost (ako postoji token vrati true, ako ne postoji vrati false)
  }

  signOut(){
    localStorage.clear();
    this.router.navigate(['login'])
  }

  decodeToken(){
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;
    console.log(jwtHelper.decodeToken(token))
    return jwtHelper.decodeToken(token)
  }

  getRoleFromToken(){
    if(this.userPayload)
      return this.userPayload.role;
  }

}
