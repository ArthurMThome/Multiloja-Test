import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {

  produtos = new MatTableDataSource<any>();
  displayedColunms: string[];

  @ViewChild(MatPaginator)
  paginator: MatPaginator

  constructor(
    private produtoService: ProdutoService
    ) { }

  ngOnInit(): void {
    this.produtoService.pegarTodos().subscribe(result => {
      this.produtos.data = result.obj;
      this.produtos.paginator = this.paginator;

      this.displayedColunms = this.exibirColunas();
    });
  }

  private exibirColunas(): string[]{
    return ['id', 'sku', 'titulo', 'descricao', 'valor', 'dataCriacao', 'dataAlterado', 'status', 'quantidade'];
  }
}
