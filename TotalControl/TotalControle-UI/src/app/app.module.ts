//Modulos Core do Angular
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

//Serviços da Aplicação
import TiposService from './services/tipos.service';
import { CategoriasService } from './services/categorias.service';
import { FuncoesService } from './services/funcoes.service';

//Componentes da Aplicação
import { ListagemCategoriasComponent, DialogExclusaoCategoriasComponent } from './componentes/Categoria/listagem-categorias/listagem-categorias.component';
import { NovaFuncaoComponent } from './componentes/Funcao/nova-funcao/nova-funcao.component';

//Modulos do Angular (Material Angular e Componentes HTTP)
import {HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {NovaCategoriaComponent } from './componentes/Categoria/nova-categoria/nova-categoria.component';
import {MatCardModule} from '@angular/material/card';
import {ReactiveFormsModule } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatDividerModule} from '@angular/material/divider';
import {MatSelectModule} from '@angular/material/select';
import { MatGridListModule } from '@angular/material/grid-list';
import { AtualizarCategoriaComponent } from './componentes/Categoria/atualizar-categoria/atualizar-categoria.component';
import {MatDialogModule} from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { DialogExclusaoFuncoesComponent, ListagemFuncoesComponent } from './componentes/Funcao/listagem-funcoes/listagem-funcoes.component';
import { AtualizarFuncaoComponent } from './componentes/Funcao/atualizar-funcao/atualizar-funcao.component';
import { RegistrarUsuarioComponent } from './componentes/Usuarios/Registro/registrar-usuario/registrar-usuario.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { NgxMaskModule } from 'ngx-mask';
import { LoginUsuarioComponent } from './componentes/Login/login-usuario/login-usuario.component';

@NgModule({
  //Aqui são as Declarações dos Compenentes da Aplicação
  declarations: [AppComponent,ListagemCategoriasComponent,NovaCategoriaComponent, AtualizarCategoriaComponent, 
                 DialogExclusaoCategoriasComponent, ListagemFuncoesComponent, NovaFuncaoComponent, AtualizarFuncaoComponent, DialogExclusaoFuncoesComponent, RegistrarUsuarioComponent, LoginUsuarioComponent
  ],
  //Nesse Import, são os Objetos que do Angular, Angular Material disponeis para a Injeção de Dependencia
  imports: [BrowserModule,AppRoutingModule,BrowserAnimationsModule,MatTableModule,
    MatIconModule,MatButtonModule,HttpClientModule,MatCardModule, ReactiveFormsModule,
    MatFormFieldModule,MatInputModule,MatDividerModule,MatSelectModule, MatGridListModule, MatDialogModule , FormsModule  ,MatAutocompleteModule ,
    MatPaginatorModule, MatSortModule, MatSnackBarModule, MatProgressBarModule, FlexLayoutModule, NgxMaskModule.forRoot()
  ],
  //Nessa Declaração são os Objetos Disponiveis para a Injeção de Dependencia da Aplicação
  providers: [
    TiposService,
    HttpClientModule,
    CategoriasService,
    FuncoesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
