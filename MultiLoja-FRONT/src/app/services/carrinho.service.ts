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
export class CarrinhoService {

  constructor(
    private http: HttpClient
    ) { }

    apiUrl = "https://localhost:7285/api/carrinho";

    pegarPorClienteId(clienteId: number): Observable<any>{
        const apiurl = `${this.apiUrl}/${clienteId}`;
        return this.http.get<any>(apiurl);
      }

  criarCarrinho(carrinho: object): Observable<any>{
    const apiurl = `${this.apiUrl}`;
    return this.http.post<any>(apiurl, carrinho);
  }

  deleterCarrinho(carrinhoId: string): Observable<any>{
    const apiurl = `${this.apiUrl}/${carrinhoId}`;
    return this.http.put<any>(apiurl, null);
  }
}
