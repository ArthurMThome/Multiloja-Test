import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(
    private http: HttpClient
    ) { }

    apiUrl = "https://localhost:7285/api/cliente";

  pegarTodos(): Observable<any>{
    return this.http.get<any>(this.apiUrl);
  }

  criarCliente(cliente: object): Observable<any>{
    const apiurl = `${this.apiUrl}`;
    return this.http.post<any>(apiurl, cliente);
  }
}
