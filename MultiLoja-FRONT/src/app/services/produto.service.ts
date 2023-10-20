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
export class ProdutoService {

  constructor(
    private http: HttpClient
    ) { }

    apiUrl = "https://localhost:7285/api/produto";

  pegarTodos(): Observable<any>{
    return this.http.get<any>(this.apiUrl);
  }

  pegarPorId(produtoId: number): Observable<any>{
    const apiurl = `${this.apiUrl}/${produtoId}`;
    return this.http.get<any>(apiurl);
  }
}
