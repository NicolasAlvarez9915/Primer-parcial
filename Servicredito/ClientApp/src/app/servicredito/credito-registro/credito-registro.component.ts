import { Component, OnInit } from '@angular/core';
import { Credito } from '../model/credito';
import { CreditoService } from 'src/app/sevices/credito.service';

@Component({
  selector: 'app-credito-registro',
  templateUrl: './credito-registro.component.html',
  styleUrls: ['./credito-registro.component.css']
})
export class CreditoRegistroComponent implements OnInit {

  credito : Credito; 
  constructor(private creditoService :CreditoService) { }

  ngOnInit() {
    this.credito = new Credito();
  }

  add(){
    this.creditoService.post(this.credito).subscribe(p => {if (p != null){
      alert("Registrado");
      this.credito = p;
    } });
  }

}
