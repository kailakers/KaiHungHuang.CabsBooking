import { Component, OnInit } from '@angular/core';
import { CabtypeService } from '../core/services/cabtype.service';
import { CabType } from '../core/shared/models/cabtype';

@Component({
  selector: 'app-cabtypes',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  cabtypes: CabType[] = [];
  constructor(private cabtypeService:CabtypeService) { }

  ngOnInit(): void {
    this.cabtypeService.getAllCabTypes().subscribe((c)=>{
      this.cabtypes = c;
      console.table(this.cabtypes);
    })
  }

}
