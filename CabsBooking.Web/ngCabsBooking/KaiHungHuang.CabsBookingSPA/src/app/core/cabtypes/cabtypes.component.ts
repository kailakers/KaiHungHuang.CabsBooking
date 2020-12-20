import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CabtypeService } from '../services/cabtype.service';
import { CabType } from '../shared/models/cabtype';

@Component({
  selector: 'app-cabtypes',
  templateUrl: './cabtypes.component.html',
  styleUrls: ['./cabtypes.component.css']
})
export class CabtypesComponent implements OnInit {
  cabType: CabType = {
    cabTypeName: "",
  }

  cabtypes: CabType[] = [];
  constructor(
    private cabTypeService:CabtypeService,
    private router: Router,
  ) { }

  loadData() {
    this.cabTypeService.getAllCabTypes().subscribe((c)=>{
      this.cabtypes = c;
      console.table(this.cabtypes);
    });
  }

  ngOnInit(): void {
    this.loadData();
  }
  createCabType() {
    this.cabTypeService.createCabTypes(this.cabType).subscribe(
      (response) => {
        this.router.navigate(["/cabtype"]);
        this.loadData();
        this.cabType = {
          cabTypeName: "",
        }
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

  updateCabType() {
    this.cabTypeService.updateCabType(this.cabType).subscribe(
      (response) => {
        this.router.navigate(["/cabtype"]);
        this.loadData();
        this.cabType = {
          cabTypeName: "",
        }
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

  getCabType(id:number) {
    this.cabTypeService.getCabTypeById(id).subscribe(c=>{
      this.cabType = c;
    });
  }

  deleteCabType(cabTypeId:number) {
    this.cabTypeService.deleteCabType(cabTypeId).subscribe(
      (response) => {
        this.router.navigate(["/cabtype"]);
        this.loadData();
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

  CabTypeAction() {
    if (this.cabType.cabTypeId==null)
      this.createCabType();
    else
      this.updateCabType();
  }
}

