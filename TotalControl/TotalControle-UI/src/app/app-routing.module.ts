import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AtualizarCategoriaComponent } from './componentes/Categoria/atualizar-categoria/atualizar-categoria.component';
import { ListagemCategoriasComponent } from './componentes/Categoria/listagem-categorias/listagem-categorias.component';
import { NovaCategoriaComponent } from './componentes/Categoria/nova-categoria/nova-categoria.component';
import { AtualizarFuncaoComponent } from './componentes/Funcao/atualizar-funcao/atualizar-funcao.component';
import { ListagemFuncoesComponent } from './componentes/Funcao/listagem-funcoes/listagem-funcoes.component';
import { NovaFuncaoComponent } from './componentes/Funcao/nova-funcao/nova-funcao.component';
import { LoginUsuarioComponent } from './componentes/Login/login-usuario/login-usuario.component'
import { RegistrarUsuarioComponent } from './componentes/Usuarios/Registro/registrar-usuario/registrar-usuario.component';

const routes: Routes = [
  {
    path : 'Categorias/listagemcategorias',component: ListagemCategoriasComponent
  },
  {
    path : 'Categorias/novacategoria',component: NovaCategoriaComponent
  },
  {
    path : 'Categorias/atualizarcategoria/:id',component: AtualizarCategoriaComponent    
  },  
  {
    path : 'Funcoes/listagemfuncoes',component: ListagemFuncoesComponent
  },
  {
    path : 'Funcoes/novafuncao',component: NovaFuncaoComponent
  },
  {
    path : 'Funcoes/atualizarfuncao/:id',component: AtualizarFuncaoComponent
  },
  {
    path : 'Usuarios/registrarusuario',component: RegistrarUsuarioComponent
  },  
  {
    path : 'Usuarios/loginusuario',component: LoginUsuarioComponent
  }        


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
