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
  clienteTiposList:any=[];
  
  //Map para mostrar a associação entre tabelas
  clientesTipoMap:Map<number, string> = new Map();

  constructor(private service:OpeaApiService) { }

  ngOnInit(): void {
    this.clienteList$ = this.service.getClienteList();
    this.tipoEmpresaList$ =  this.service.getTipoEmpresaList();
    this.atualizarTiposEmpresa();

  }


  //Geral
  modalTitle:string = 'Nova Empresa';
  activateAddEditOpeaComponet:boolean =false;
  Opea:any;

  modalAdd(){
    this.Opea= {
       id:0,
       nomeEmpresa:null,
       tipoEmpresaID:null 

    }
    this.modalTitle ="Nova Empresa";
    this.activateAddEditOpeaComponet = true;        
  }
  
  modalEdit(item:any){
    this.Opea=item;
    this.modalTitle ="Edição de Empresa";
    this.activateAddEditOpeaComponet = true;        

  }
  
  delete(item:any){
      if(confirm(`você tem certeza que quer deletar o cliente ${item.id}?`))
      {
        this.service.deleteCliente(item.id).subscribe(res =>{
          var closeModalBtn = document.getElementById('delete-edit-modal-close');
          if(closeModalBtn)
          {
            closeModalBtn.click();
          }
    
          var showdeleteSuccess = document.getElementById("delete-success-alert");
          if (showdeleteSuccess){
            showdeleteSuccess.style.display='block';      
          }
    
          setTimeout(function(){
            if(showdeleteSuccess)
            {
              showdeleteSuccess.style.display='none';      
            }
          },4000);
        })            
      }
  }

  modalClose(){
    this.activateAddEditOpeaComponet = false;
    this.clienteList$ = this.service.getClienteList();
  }

  atualizarTiposEmpresa(){
    this.service.getTipoEmpresaList().subscribe(data => {
      this.clienteTiposList = data;
      for (let i = 0; i< data.length; i++){
        this.clientesTipoMap.set(this.clienteTiposList[i].id, this.clienteTiposList[i].tipo)  
      }    
  })}
}
