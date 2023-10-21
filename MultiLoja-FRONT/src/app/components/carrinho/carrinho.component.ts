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
  totalCarrinho = 0;
  finalizarcompra = false;

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
      
      if(this.carrinho === null){
        return;
      }
      
      this.carrinhoCodigo = this.carrinho[0].codigoCarrinho;
      var carrinhoIds = [];

      this.carrinho.forEach(element => {
        carrinhoIds.push(element.produtoId);
      });   

      this.produtoService.pegarPorIds(carrinhoIds.join(",")).subscribe(result => {
        this.produtos.data = result.obj;
        this.produtos.paginator = this.paginator;
  
        this.displayedColunms = this.exibirColunas();

        this.produtos.data.forEach(item =>{
          this.totalCarrinho += item.valor;
        })
      });
    });    
  }

  finalizarCompraCarrinho(){
    this.finalizarcompra = true;
    this.limparCarrinho();
  }

  limparCarrinho(){

    var carrinhoIds = [];

    this.carrinho.forEach(element => {
      carrinhoIds.push(element.carrinhoId);
    });  

    this.carrinhoService.deleterCarrinho(carrinhoIds.join(",")).subscribe(result => {
      
      this.atualizarList(); 
    }); 
  }

  private exibirColunas(): string[]{
    return ['id', 'sku', 'titulo', 'descricao', 'valor'];
  }
}
