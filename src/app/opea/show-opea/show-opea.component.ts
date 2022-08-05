import { Component, OnInit } from '@angular/core';
import { map, Observable } from 'rxjs';
import { OpeaApiService } from 'src/app/opea-api.service';

@Component({
  selector: 'app-show-opea',
  templateUrl: './show-opea.component.html',
  styleUrls: ['./show-opea.component.css']
})
export class ShowOpeaComponent implements OnInit {

  clienteList$!:Observable<any[]>;
  tipoEmpresaList$!:Observable<any[]>;
  
  //Map para mostrar a associação entre tabelas
  clientesTipoMap:Map<number, string> = new Map();

  constructor(private service:OpeaApiService) { }

  ngOnInit(): void {
    this.clienteList$ = this.service.getClienteList();
    this.tipoEmpresaList$ =  this.service.getTipoEmpresaList();
  }

}
