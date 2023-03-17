import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {

  title:string = 'angularFIT2';
  ime_prezime:string = '';
  opstina: string = '';
  studentPodaci: any;
  filter_ime_prezime: boolean;
  filter_opstina: boolean;

  urediStudent:any;
  SveOpstine:any=[];
  Naslov:"";

  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  testirajWebApi() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;
    });
  }

  ngOnInit(): void {
    this.testirajWebApi();
    this.GetOpstine();
  }

  filtrirajStudente(){
    if(this.studentPodaci==null)
      return [];
    return this.studentPodaci.filter((x:any)=>
      ((x.ime.toLowerCase().startsWith(this.ime_prezime) || x.prezime.toLowerCase().startsWith(this.ime_prezime) ||
      this.filter_ime_prezime==false)&&
      (this.filter_opstina==false ||x.opstina_rodjenja.description.toLowerCase().startsWith(this.opstina)))
    );
  }

  Uredi(s:any) {
    this.urediStudent=s;
  }

  Inicijaliziraj() {
    this.urediStudent={
      id:0,
      ime:this.ime_prezime,
      prezime:"",
      opstina_rodjenja_id:0
    }
  }
  Snimi(){
    this.httpKlijent.post(MojConfig.adresa_servera+"/Student/Snimi",this.urediStudent,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.testirajWebApi();
      this.urediStudent=null;
    })
  }

  GetOpstine(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/Opstina/GetByAll").subscribe((s:any)=>{
      this.SveOpstine=s;
    })
  }

  Obrisi(s: any) {
    this.httpKlijent.post(MojConfig.adresa_servera+"/Student/Obrisi?id="+s.id,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.testirajWebApi();
    })
  }

  OtvoriMaticnuKnjigu(s:any){
    this.router.navigate(["student-maticnaknjiga",s.id]);
  }
}
