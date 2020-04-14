import { Component, OnInit } from '@angular/core';
import {CreditoService} from '../../sevices/credito.service';
import { Credito } from '../model/credito';

@Component({
  selector: 'app-credito-consulta',
  templateUrl: './credito-consulta.component.html',
  styleUrls: ['./credito-consulta.component.css']
})
export class CreditoConsultaComponent implements OnInit {

  creditos: Credito[];
  constructor(private creditoService: CreditoService) { }

  ngOnInit() {
    this.get();
  }
  
  get(){
    this.creditoService.get().subscribe(result => {this.creditos = result;});
  }
}
