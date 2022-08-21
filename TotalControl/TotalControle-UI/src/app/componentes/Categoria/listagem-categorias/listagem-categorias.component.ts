import { Component, Inject,  OnInit, ViewChild } from '@angular/core';
import { CategoriasService } from 'src/app/services/categorias.service';
import { MatTableDataSource } from '@angular/material/table';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { FormControl } from '@angular/forms';
import { map, Observable, startWith } from 'rxjs';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AnimationDurations } from '@angular/material/core';


@Component({
  selector: 'app-listagem-categorias',
  templateUrl: './listagem-categorias.component.html',
  styleUrls: ['./listagem-categorias.component.css']
})
export class ListagemCategoriasComponent implements OnInit {

  categorias = new MatTableDataSource<any>();
  displayedColumns: string[];
  autoCompleteInput = new FormControl();
  opcoesCategorias : string[] =[];
  nomesCategorias : Observable<string[]>;

  //Adiciona o Paginador na Pagina HTML
  @ViewChild(MatPaginator, {static:true})
  paginator: MatPaginator;
  
  //Adiciona a Ordenação das Colunas
  //@ViewChild(MatSort, {static:true})
  //sortPagina: MatSort;

  //Implementação da Ordernação da Aula não funcionou, então adicionei a implementacação abaixo e funcionou corretamente
  @ViewChild(MatSort) set matSort(sort: MatSort) {
    if (!this.categorias.sort) {this.categorias.sort = sort;}}


  constructor(private categoriasServices: CategoriasService, 
    private dialog: MatDialog) { }

  ngOnInit(): void {
      this.categoriasServices.PegarTodos().subscribe(resultado => {
      
      //Faz um forEach para carregar as Categorias Cadastradas
      //na variavel opcoesCategoria
      resultado.forEach(categoria => {
        this.opcoesCategorias.push(categoria.nome);
      });       
      
      //Carrega as Categorias com o resultado da chamada do WebService
      this.categorias.data = resultado;

      //Vincula o Paginador com as Categorias Carregadas
      this.categorias.paginator = this.paginator;

    });

    //Adiciona a Odernação da Pagina      
    
    //this.categorias.sort = this.sortPagina;

    this.displayedColumns = this.ExibirColunas();
    this.nomesCategorias = this.autoCompleteInput.valueChanges.pipe(startWith(''), map(nome => this.FiltrarNome(nome)));
  }

  ExibirColunas(): string[] {
    return ['nome', 'icone', 'tipo', 'acoes'];
  }
  
  AbrirDialog(categoriaId: any, nome: any):void {
    this.dialog.open(DialogExclusaoCategoriasComponent, {
      data: {
        categoriaId : categoriaId,
        nome: nome
      }
    }).afterClosed().subscribe(resultado =>{
      if (resultado ==true){
        //O Comando abaixo server para você conseguir debugar o Código em Tempo de Execução
        //debugger;
        this.categoriasServices.PegarTodos().subscribe(dados =>{
            this.categorias.data = dados;
        });
      }
    });
  }

  FiltrarNome(nome : string): string[]{
    //Se o nome, tiramos todos os espaços em Branco
    //For maior ou igual a 4
    //Chamamos o Serviço de Filtrar as Categorias, também já mudamos para LowerCase o valor passado
    if (nome.trim().length>=4 ) {
      this.categoriasServices.FiltrarCategorias(nome.toLocaleLowerCase()).subscribe(resultado =>{
        this.categorias.data = resultado;
      });      
    }
    //Caso contrario, carrega todas as categorias
    else{
      if (nome ==''){
        this.categoriasServices.PegarTodos().subscribe(resultado =>{
          this.categorias.data = resultado;
        });
      }
    }
    //O Retorno da Função é fazer uma comparação da categoria com o nome passado
    //Substring no Angular
    return this.opcoesCategorias.filter((categoria) =>
      //Faz a comparação do Nome
      //a Função abaixo é equivalente a uma Substring
      //Jogamos o valor para letras minusculas para efetuar 
      //a comparação corretamente
      categoria.toLowerCase().includes(nome.toLocaleLowerCase())
    );
  }
}

//Efetua a Criação do Componente para a Exibição da Caixa de Dialago
//Que utiliza o Angular Material
@Component({
  selector: 'app-dialog-exclusao-categorias',
  templateUrl: 'dialog-exclusao-categorias.html'
})
export class DialogExclusaoCategoriasComponent{
  constructor(@Inject (MAT_DIALOG_DATA) public dados:any, 
  private categoriasService: CategoriasService,
  private snackBar: MatSnackBar){ }

  //Dentro do Componente chamamos o serviço de Exclusão da Categoria
  ExcluirCategoria(categoriaId: number): void {
    this.categoriasService.DeletarCategoria(categoriaId).subscribe((resultado) =>{
      this.snackBar.open(resultado.mensagem, '',
        {
          duration: 2000,
          horizontalPosition: 'center',
          verticalPosition: 'top'
        });
    });
 }  
}
