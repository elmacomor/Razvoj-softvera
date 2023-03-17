import { Component, OnInit } from '@angular/core';
import {AuthService} from "../services/auth.service";
import {ProizvodGetAllVM} from "../proizvodi/ProizvodGetAllVM";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../proizvodi/MojConfig";
import {Router} from "@angular/router";

@Component({
  selector: 'app-pregled-proizvoda',
  templateUrl: './pregled-proizvoda.component.html',
  styleUrls: ['./pregled-proizvoda.component.css']
})
export class PregledProizvodaComponent implements OnInit {

  constructor(private httpKlijent: HttpClient,private ruter:Router) { }
  proizvodPodaci:ProizvodGetAllVM[]=[];
  pretraga:string = '';
  gradoviPodaci: any[]=[];
  selectedGrad: any = null;
  selectedSortiranje: any = null;
  ngOnInit(): void {
    this.DobaviProizvode();
    this.getGradovi();
  }
  DobaviProizvode(){
    this.httpKlijent.get<ProizvodGetAllVM>(MojConfig.adresaServera+"/Proizvod/GetProizvodi").subscribe((x:any)=>{this.proizvodPodaci=x;});
  }


  /*GetProizvodi(){
    if(this.proizvodPodaci==null)
      return [];
    return this.proizvodPodaci.filter((p:any)=>
      p.marka.startsWith(this.pretraga)
    )
  }*/

  GetProizvodi(){
    if(this.proizvodPodaci==null)
      return [];

    let filteredProizvodi = this.proizvodPodaci.filter((p:any)=>
      p.marka.toLowerCase().startsWith(this.pretraga.toLowerCase())
    );

   /* if (this.selectedGrad) {
      filteredProizvodi = filteredProizvodi.filter((p:any) =>
        p.grad.toLowerCase() === this.selectedGrad.toLowerCase()
      );
    }*/

    if (this.selectedSortiranje) {
      if (this.selectedSortiranje === 'asc') {
        filteredProizvodi = filteredProizvodi.sort((a:any, b:any) =>
          a.cijena - b.cijena
        );
      } else if (this.selectedSortiranje === 'desc') {
        filteredProizvodi = filteredProizvodi.sort((a:any, b:any) =>
          b.cijena - a.cijena
        );
      }
    }

    return filteredProizvodi;
  }



  GetSlikaBase64Umanjena_fs(p:ProizvodGetAllVM){
    return "data:image/png;base64,"+p.slika_umanjena;
  }
  GetSlikaBase64_fs(p:ProizvodGetAllVM){
    return "data:image/png;base64,"+p.slika_bajtovi;
  }


  OtvoriProizvod(x:any) {
    this.ruter.navigate(["otvori-proizvode",x.id]);
  }

  getGradovi() {
    this.httpKlijent.get(MojConfig.adresaServera+"/Grad/GetAll").subscribe((x:any)=>{
      this.gradoviPodaci = x;
    });
  }
}
