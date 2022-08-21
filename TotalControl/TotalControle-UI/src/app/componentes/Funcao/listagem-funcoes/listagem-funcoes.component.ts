import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { map, Observable, startWith } from 'rxjs';
import { FuncoesService } from 'src/app/services/funcoes.service';


@Component({
  selector: 'app-listagem-funcoes',
  templateUrl: './listagem-funcoes.component.html',
  styleUrls: ['./listagem-funcoes.component.css']
})
export class ListagemFuncoesComponent implements OnInit {

  funcoes = new MatTableDataSource<any>();
  displayedColumns: string[];
  autoCompleteInput = new FormControl();
  opcoesFuncoes : string[] =[];
  nomesFuncoes : Observable<string[]>;

  //Adiciona o Paginador na Pagina HTML
  @ViewChild(MatPaginator, {static:true})
  paginator: MatPaginator;
    
  //Implementação da Ordernação da Aula não funcionou, então adicionei a implementacação abaixo e funcionou corretamente
  @ViewChild(MatSort) set matSort(sort: MatSort) {
    if (!this.funcoes.sort) {this.funcoes.sort = sort;}}


  constructor(private funcoesService: FuncoesService,
              private dialog : MatDialog) { }

  ngOnInit(): void {
      
    this.funcoesService.PegarTodos().subscribe(resultado => {
      
      
      resultado.forEach((funcao) => {
        this.opcoesFuncoes.push(funcao.name);
      }); 

      //Carrega as Categorias com o resultado da chamada do WebService
      this.funcoes.data = resultado;      
      //Vincula o Paginador com as Categorias Carregadas
      this.funcoes.paginator = this.paginator;
      
  });

    this.displayedColumns = this.ExibirColunas();  
    this.nomesFuncoes = this.autoCompleteInput.valueChanges.pipe(startWith(''), map((nome) => this.FiltrarNomes(nome)));
    
  }
  ExibirColunas(): string[] {
    return ['name', 'descricao', 'acoes'];
  }
 
  FiltrarNomes(nome: string): string[] {
    if (nome.trim().length >= 4) {
      this.funcoesService
        .FiltrarFuncoes(nome.toLowerCase())
        .subscribe((resultado) => {
          this.funcoes.data = resultado;
        });
    } else {
      if (nome === '') {
        this.funcoesService.PegarTodos().subscribe((resultado) => {
          this.funcoes.data = resultado;
        });
      }
    }
    return this.opcoesFuncoes.filter((funcao) =>
      funcao.toLowerCase().includes(nome.toLowerCase())
    );
  }

  
  AbrirDialog(funcaoId:string , name:string) : void {
    this.dialog.open(DialogExclusaoFuncoesComponent, {
      data:{
        funcaoId : funcaoId,
        name : name
      },
    }).afterClosed().subscribe(resultado => {
      if (resultado == true){
        this.funcoesService.PegarTodos().subscribe(dados => {
          this.funcoes.data = dados;
          this.funcoes.paginator = this.paginator;          
        });
        this.displayedColumns = this.ExibirColunas();
      }
    });
  }
}

@Component({
  selector:'app-dialog-exclusao-funcoes',
  templateUrl: 'dialog-exclusao-funcoes.html'

})
export class DialogExclusaoFuncoesComponent{
  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
  private funcoesService: FuncoesService,
  private snackBar: MatSnackBar){}

  ExcluirFuncao(funcaoId:string): void {    
    this.funcoesService.DeletarFuncao(funcaoId).subscribe(resultado =>{
      this.snackBar.open(resultado.mensagem, '', {
        duration:2000,
        horizontalPosition: 'center',
        verticalPosition: 'top'
      });
    });
  }
}

