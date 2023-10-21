import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CarrinhoService } from 'src/app/services/carrinho.service';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-loja',
  templateUrl: './loja.component.html',
  styleUrls: ['./loja.component.css']
})
export class LojaComponent {

  produtos = new MatTableDataSource<any>();
  displayedColunms: string[];

  userLogado = false;
  user = "";

  @ViewChild(MatPaginator)
  paginator: MatPaginator

  constructor(
    private produtoService: ProdutoService,
    private carrinhoService: CarrinhoService
    ) { }

  ngOnInit(): void {    
    this.user = localStorage.getItem('user');
    if(this.user != null){
      this.userLogado = true;
    }

    this.atualizarList();
  }

  atualizarList() : void {
    this.produtoService.pegarTodos().subscribe(result => {
      this.produtos.data = result.obj;
      this.produtos.paginator = this.paginator;

      this.displayedColunms = this.exibirColunas();
    });

  }

  adicionarAoCarrinho(id: any){

    var codigoCarrinho = "abc"+(Number(this.user)*50);

    const carrinho = {
      produtoId: id,
      clienteId: Number(this.user),
      codigoCarrinho: codigoCarrinho
    };

    this.carrinhoService.criarCarrinho(carrinho).subscribe(result => {
      this.produtos.data = result.obj;
      this.produtos.paginator = this.paginator;

      this.displayedColunms = this.exibirColunas();

      this.atualizarList();
    });    
  }

  private exibirColunas(): string[]{
    return ['sku', 'titulo', 'descricao', 'valor', 'acoes'];
  }
}
