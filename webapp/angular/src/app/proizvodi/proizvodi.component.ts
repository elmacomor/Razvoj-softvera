import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "./MojConfig";
import {ProizvodGetAllVM} from "./ProizvodGetAllVM";
import {AuthService} from "../services/auth.service";

@Component({
  selector: 'app-proizvodi',
  templateUrl: './proizvodi.component.html',
  styleUrls: ['./proizvodi.component.css']
})
export class ProizvodiComponent implements OnInit {

 proizvodPodaci:ProizvodGetAllVM[]=[];
 noviProizvod?:ProizvodGetAllVM | null;
 tipProizvodaPodaci:any;
  constructor(private httpKlijent: HttpClient) {

  }

  ngOnInit(): void {
    this.DobaviProizvode();
    this.DobaviTipove();
  }
  DobaviProizvode(){
    this.httpKlijent.get<ProizvodGetAllVM>(MojConfig.adresaServera+"/Proizvod/GetProizvodi").subscribe((x:any)=>{this.proizvodPodaci=x;});
  }

  DobaviTipove(){
    this.httpKlijent.get(MojConfig.adresaServera+"/ProizvodiTip/GetProizvodiTip").subscribe(x=>this.tipProizvodaPodaci=x);
  }
 GetProizvodi(){
    if(this.proizvodPodaci==null)
      return [];
    return this.proizvodPodaci;
 }

 SnimiProizvode(){
    this.httpKlijent.post(MojConfig.adresaServera+"/Proizvod/Snimi",this.noviProizvod).subscribe(x=>{
      this.DobaviProizvode();
      this.noviProizvod=null;
    });
 }
 GetSlikaBase64Umanjena_fs(p:ProizvodGetAllVM){
    return "data:image/png;base64,"+p.slika_umanjena;
 }
  GetSlikaBase64_fs(p:ProizvodGetAllVM){
    return "data:image/png;base64,"+p.slika_bajtovi;
  }
 noviProizvod_dugme(){
    this.noviProizvod={
      id:0,
      marka:"",
      cijena:100,
      slika_bajtovi:"",
      boja:"",
      specifikacije:"",
      proizvodTipID:1,
      proizvodTipNaziv:"",
      kratakOpisProizvoda:""
    }
 }
 generisi_preview(){
   // @ts-ignore
   var file = document.getElementById("slika-input").files[0];
   if (file) {
     var reader = new FileReader();
     let this2=this;
     reader.onload = function () {
       this2.noviProizvod!.slika_bajtovi = reader.result?.toString();
     }

     // @ts-ignore
     reader.readAsDataURL(file);
   }
 }


}
