import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CarrinhoService } from 'src/app/services/carrinho.service';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css']
})
export class CarrinhoComponent {
  produtos = new MatTableDataSource<any>();
  displayedColunms: string[];
  userLogado = "";
  carrinho = [];
  carrinhoCodigo = "";

  @ViewChild(MatPaginator)
  paginator: MatPaginator

  constructor(
    private carrinhoService: CarrinhoService,
    private produtoService: ProdutoService
    ) { }

  ngOnInit(): void {
    this.userLogado = localStorage.getItem('user');
    
    this.atualizarList();    
  }

  atualizarList() : void {
    this.carrinhoService.pegarPorClienteId(Number(this.userLogado)).subscribe(result => {
      this.carrinho = result.obj;
      this.carrinhoCodigo = this.carrinho[0].codigoCarrinho;

      if(this.carrinho === null){
        return;
      }
      
      var carrinhoIds = [];

      this.carrinho.forEach(element => {
        carrinhoIds.push(element.produtoId);
      });   

      this.produtoService.pegarPorIds(carrinhoIds.join(",")).subscribe(result => {
        this.produtos.data = result.obj;
        this.produtos.paginator = this.paginator;
  
        this.displayedColunms = this.exibirColunas();
      });
    });    
  }

  private exibirColunas(): string[]{
    return ['id', 'sku', 'titulo', 'descricao', 'valor'];
  }
}
