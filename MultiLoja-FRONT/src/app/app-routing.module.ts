import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ClienteComponent } from './components/cliente/cliente.component';
import { CarrinhoComponent } from './components/carrinho/carrinho.component';
import { LogarComponent } from './components/logar/logar.component';
import { LojaComponent } from './components/loja/loja.component';
import { ProdutoComponent } from './components/produto/produto.component';

const routes: Routes = [
  { path: 'cliente', component: ClienteComponent},
  { path: 'carrinho', component: CarrinhoComponent},
  { path: 'logar', component: LogarComponent},
  { path: 'loja', component: LojaComponent},
  { path: 'produto', component: ProdutoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
