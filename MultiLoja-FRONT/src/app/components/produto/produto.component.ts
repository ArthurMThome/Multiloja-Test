import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { ProdutoService } from 'src/app/services/produto.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {

  produtos = new MatTableDataSource<any>();
  displayedColunms: string[];
  formulario: FormGroup;

  @ViewChild(MatPaginator)
  paginator: MatPaginator

  get form() {
    return this.formulario.controls;
  }

  constructor(
    private produtoService: ProdutoService
    ) { }

  ngOnInit(): void {
    this.atualizarList();

    this.formulario = new FormGroup({
      sku: new FormControl('', [Validators.required, Validators.minLength(4)]),
      titulo: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(15)]),
      descricao: new FormControl('', [Validators.required, Validators.maxLength(500)]),
      valor: new FormControl('', [Validators.required]),
      quantidade: new FormControl('', [Validators.required, Validators.minLength(1)])
    });
  }

  atualizarList() : void {
    this.produtoService.pegarTodos().subscribe(result => {
      this.produtos.data = result.obj;
      this.produtos.paginator = this.paginator;

      this.displayedColunms = this.exibirColunas();
    });

    this.formulario = new FormGroup({
      sku: new FormControl('', [Validators.required, Validators.maxLength(10)]),
      titulo: new FormControl('', [Validators.required, Validators.maxLength(15)]),
      descricao: new FormControl('', [Validators.required, Validators.maxLength(500)]),
      valor: new FormControl('', [Validators.required]),
      quantidade: new FormControl('', [Validators.required, Validators.maxLength(15)])
    });
  }

  salvarNomes() : void {
    const produtoForm = this.formulario.value;

    const produto = {
      sku: produtoForm.sku,
      titulo: produtoForm.titulo,
      descricao: produtoForm.descricao,
      valor: produtoForm.valor,
      quantidade: produtoForm.quantidade
    };

    this.produtoService.criarProduto(produto).subscribe(result => {
      
      this.atualizarList();
    });
  }


  private exibirColunas(): string[]{
    return ['id', 'sku', 'titulo', 'descricao', 'valor', 'dataCriacao', 'dataAlterado', 'status', 'quantidade'];
  }
}
