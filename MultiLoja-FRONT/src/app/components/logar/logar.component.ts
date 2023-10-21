import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ClienteService } from 'src/app/services/cliente.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-logar',
  templateUrl: './logar.component.html',
  styleUrls: ['./logar.component.css']
})
export class LogarComponent {
  clientes = new MatTableDataSource<any>();
  displayedColunms: string[];
  formulario: FormGroup;
  startDate = new Date(1990, 0, 1);

  userLogado = false;
  user = "";

  @ViewChild(MatPaginator)
  paginator: MatPaginator

  get form() {
    return this.formulario.controls;
  }

  constructor(
    private clienteService: ClienteService
    ) { }

  ngOnInit(): void {
    this.atualizarList();    

    this.user = localStorage.getItem('user');
  }

  atualizarList() : void {
    this.clienteService.pegarTodos().subscribe(result => {
      this.clientes.data = result.obj;
      this.clientes.paginator = this.paginator;

      this.displayedColunms = this.exibirColunas();
    });

    this.formulario = new FormGroup({
      primeiroNome: new FormControl('', [Validators.required, Validators.pattern('[a-zA-Z ]*'), Validators.maxLength(10)]),
      ultimoNome: new FormControl('', [Validators.required, Validators.pattern('[a-zA-Z ]*'), Validators.maxLength(15)]),
      celular: new FormControl('', [Validators.required, Validators.pattern("^[0-9]{11}$")]),
      email: new FormControl('', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]),
      dataNascimento: new FormControl('', [Validators.required]),
      documento: new FormControl('', [Validators.required, Validators.minLength(11), Validators.maxLength(14)])
    });
  }

  salvarCliente() : void {
    const produtoForm = this.formulario.value;
       
    const cliente = {
      primeiroNome: produtoForm.primeiroNome,
      ultimoNome: produtoForm.ultimoNome,
      celular: produtoForm.celular,
      email: produtoForm.email,
      dataNascimento: produtoForm.dataNascimento,
      documento: produtoForm.documento.toString()
    };

    
    this.clienteService.criarCliente(cliente).subscribe(result => {
      
      this.atualizarList();
    });
  }

  logar(id: any){
    localStorage.setItem('user', id);
    this.userLogado = true;
    this.user = id;
  }

  private exibirColunas(): string[]{
    return ['id', 'documento', 'primeiroNome', 'ultimoNome', 'email', 'acoes'];
  }
}
