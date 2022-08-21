import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Categoria } from '../models/Categoria';

const httpOptions = {
  headers : new HttpHeaders ({
    'Content-Type' : 'application/json'
  })
 };
 
@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  url: string ='https://localhost:7137/api/v1/Categorias';                

  constructor(private http: HttpClient) { }
  
  PegarTodos(): Observable<Categoria[]>  {
    return this.http.get<Categoria[]>(this.url);        
  };

  PegarCategoriaId(categoriaId:number): Observable<Categoria>  {
    
    const apiUrl = `${this.url}/${categoriaId}`;
    return this.http.get<Categoria>(apiUrl);        
    
  };

  NovaCategoria(categoria: Categoria):Observable<any>{
    return this.http.post<Categoria>(this.url, categoria, httpOptions);    
  }

  AtualizarCategoria(categoriaId:number, categoria: Categoria):Observable<any>{
    const apiurl= `${this.url}/${categoriaId}`;
    return this.http.put<Categoria>(apiurl, categoria, httpOptions);    
  }

  DeletarCategoria(categoriaId:number):Observable<any>{
    const apiurl= `${this.url}/${categoriaId}`;

    return this.http.delete<number>(apiurl, httpOptions);

  }

  FiltrarCategorias(nomeCategoria:string):Observable<Categoria[]>{
    const apiurl= `${this.url}/FiltrarCategorias/${nomeCategoria}`;
    return this.http.get<Categoria[]>(apiurl);

  }

}
