import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tipo } from '../models/tipos';

const httpOptions = {
  headers : new HttpHeaders ({
    'Content-Type' : 'application/json'
  })
 };

@Injectable({
  providedIn: 'root'
})
export default class TiposService {
  
  url: string ='https://localhost:7137/api/Tipos';

  constructor(private http: HttpClient) { }

  PegarTodos(): Observable<Tipo[]>  {
    return this.http.get<Tipo[]>(this.url);        
  };
}
