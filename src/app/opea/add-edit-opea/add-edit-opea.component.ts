import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { OpeaApiService } from 'src/app/opea-api.service';

@Component({
  selector: 'app-add-edit-opea',
  templateUrl: './add-edit-opea.component.html',
  styleUrls: ['./add-edit-opea.component.css']
})
export class AddEditOpeaComponent implements OnInit {

  clienteList$!:Observable<any[]>;
  tipoEmpresaList$!:Observable<any[]>;

  constructor(private service:OpeaApiService) { }

  @Input() cliente:any;
  id:number=0;
  nomeEmpresa:string="";
  tipoEmpresaID:number=0;

  addCliente(){
    var cliente = {
      nomeEmpresa:this.nomeEmpresa,
      tipoEmpresaID:this.tipoEmpresaID
    }  
    this.service.addCliente(cliente).subscribe(res =>{
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if(closeModalBtn)
      {
        closeModalBtn.click();
      }

      var showAddSuccess = document.getElementById("add-success-alert");
      if (showAddSuccess){
        showAddSuccess.style.display='block';      
      }

      setTimeout(function(){
        if(showAddSuccess)
        {
          showAddSuccess.style.display='none';      
        }
      },4000);
    })
  }

  updateCliente(){
    var cliente = {
      id: this.id,
      nomeEmpresa:this.nomeEmpresa,
      tipoEmpresaID:this.tipoEmpresaID
    } 
    var id:number = this.id;
    this.service.updateCliente(id,cliente).subscribe(res =>{
      var closeModalBtn = document.getElementById('update-edit-modal-close');
      if(closeModalBtn)
      {
        closeModalBtn.click();
      }

      var showupdateSuccess = document.getElementById("update-success-alert");
      if (showupdateSuccess){
        showupdateSuccess.style.display='block';      
      }

      setTimeout(function(){
        if(showupdateSuccess)
        {
          showupdateSuccess.style.display='none';      
        }
      },4000);
    })    
  }

  ngOnInit(): void {
    this.id = this.cliente.id;
    this.nomeEmpresa = this.cliente.nomeEmpresa;
    this.tipoEmpresaID = this.cliente.tipoEmpresaID;
    this.tipoEmpresaList$ = this.service.getTipoEmpresaList();
    this.clienteList$ = this.service.getClienteList();

  }

}
