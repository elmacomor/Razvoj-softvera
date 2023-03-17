import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {

  StudentID:any;
  MaticnaKnjiga:any=[];
 dodajGodinu:any;
 akademskeGod:any;
 ovjeriPodaci:any;
  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {}

  ovjeriLjetni(s:any) {

  }

  upisLjetni(s:any) {

  }

  ovjeriZimski(s:any) {
      this.ovjeriPodaci={
        id:s.id,
        datum_ovjere_zimski:new Date(),
        napomena_za_ovjeru:""
      }

  }

  ngOnInit(): void {
    this.route.params.subscribe((a:any)=>{
      this.StudentID=+a["id"];
    })
    this.UcitajPodatke();
    this.dobaviGodine();
  }
  UcitajPodatke(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/MaticnaKnjiga/GetMaticnaPodaci?id="+this.StudentID).subscribe((x:any)=>{
      this.MaticnaKnjiga=x;
    })
  }
  dobaviGodine(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/AkademskeGodine/GetAll_ForCmb").subscribe((s:any)=>{
      this.akademskeGod=s;
    })
  }
  Inicijaliziraj(){
    this.dodajGodinu={
      id:0,
      godina:1,
      datum_upisa_zimski:new Date(),
      cijena_skolarine:1,
      obnova:false,
      akademska_godina_id:1,
      student_id: this.StudentID
    }
  }
  Snimi(){
    for(let x of this.MaticnaKnjiga.godine){
      if(x.godina==this.dodajGodinu.godina&& this.dodajGodinu.obnova==false){
        porukaError("Godina je vec dodana, da li je u pitanju obnova?");
        return;
      }
    }
    this.httpKlijent.post(MojConfig.adresa_servera+"/MaticnaKnjiga/Snimi",this.dodajGodinu,MojConfig.http_opcije()).subscribe((x:any)=>{
        this.UcitajPodatke();
        this.dodajGodinu=null;
        porukaSuccess("Uspjesno upisana godina");
    }
    )
  }

  Ovjeri() {
    this.httpKlijent.post(MojConfig.adresa_servera+"/MaticnaKnjiga/Ovjeri",this.ovjeriPodaci,MojConfig.http_opcije()).subscribe((s:any)=>{
      this.UcitajPodatke();
      this.ovjeriPodaci=null;
      porukaSuccess("Uspjesno ovjeren semestar");
    })
  }
}
