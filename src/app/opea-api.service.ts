import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OpeaApiService {
  readonly OpeaApiUrl ="https://localhost:7230/api/v1";


  constructor(private http: HttpClient) { }
  

  //Clientes 
  //Busca os Clientes - Get
  getClienteList():Observable<any>{
    return this.http.get<any>(this.OpeaApiUrl + '/Cliente');
  }

  //Adiciona os Clientes - Post
  addCliente(data:any){
    return this.http.post(this.OpeaApiUrl + '/Cliente', data);
  }

  //Altera os Clientes - Put
  updateCliente(id:number|string, data:any){
    return this.http.put(this.OpeaApiUrl + `/Cliente/${id}`, data);
  }

  //Deleta os Clientes - Delete
  deleteCliente(id:number|string){
    return this.http.delete(this.OpeaApiUrl + `/Cliente/${id}`);
  }


  //Tipos de Empresas
  //Busca os Tipos de Empresas - Get
  getTipoEmpresaList():Observable<any>{
    return this.http.get<any>(this.OpeaApiUrl + '/TipoEmpresas');
  }

  //Adiciona os Tipos de Empresas - Post
  addTipoEmpresa(data:any){
    return this.http.post(this.OpeaApiUrl + '/TipoEmpresas', data);
  }

  //Altera os Tipos de Empresas - Put
  updateTipoEmpresa(id:number|string, data:any){
    return this.http.put(this.OpeaApiUrl + `/TipoEmpresas/${id}`, data);
  }

  //Deleta os Tipos de Empresas - Delete
  deleteTipoEmpresa(id:number|string){
    return this.http.delete(this.OpeaApiUrl + `/TipoEmpresas/${id}`);
  }

}
