import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Funcao } from '../models/Funcao';

const httpOptions ={
  headers : new HttpHeaders({
    'Content-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class FuncoesService {

  url: string ='https://localhost:7137/api/v1/Funcoes';                

  constructor(private http: HttpClient) { }

  PegarTodos(): Observable<Funcao[]>  {
    return this.http.get<Funcao[]>(this.url);        
  };

  PegarPeloId(funcaoId:string): Observable<Funcao>  {
    
    const apiUrl = `${this.url}/${funcaoId}`;
    return this.http.get<Funcao>(apiUrl);        
    
  };

  //Quando não tem um tipo definido que será retornado na Função é utilizado o observable<any> = qualquer coisa no retorno
  NovaFuncao(funcao: Funcao):Observable<any>{
    return this.http.post<Funcao>(this.url, funcao, httpOptions);    
  }

  AtualizarFuncao(funcaoId:string, funcao: Funcao):Observable<any>{
    const apiUrl = `${this.url}/${funcaoId}`;
    return this.http.put<Funcao>(apiUrl, funcao, httpOptions);    
  }

  DeletarFuncao(funcaoId:string):Observable<any>{
    const apiurl= `${this.url}/${funcaoId}`;
    return this.http.delete<string>(apiurl, httpOptions);

  }

  FiltrarFuncoes(nomeFuncao:string):Observable<Funcao[]>{
    const apiurl= `${this.url}/FiltrarFuncoes/${nomeFuncao}`;
    return this.http.get<Funcao[]>(apiurl);

  }

}
