import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Funcao } from 'src/app/models/Funcao';
import { FuncoesService } from 'src/app/services/funcoes.service';

@Component({
  selector: 'app-atualizar-funcao',
  templateUrl: './atualizar-funcao.component.html',
  styleUrls: ['../listagem-funcoes/listagem-funcoes.component.css']
})
export class AtualizarFuncaoComponent implements OnInit {

  nomeFuncao: string;
  funcao : Observable<Funcao>;
  funcaoId: string;  
  formulario:any;
  erros:string[]; //Variaveis de Erros para receber as Mensagens do BackEnd

  constructor(private router: Router, 
              private route: ActivatedRoute,  
              private funcoesService : FuncoesService,
              private snackBar: MatSnackBar) { } 

  ngOnInit(): void {
    this.erros = [];
    this.funcaoId = this.route.snapshot.params['id'];
    

    this.funcoesService.PegarPeloId(this.funcaoId).subscribe(resultado =>{
      this.nomeFuncao = resultado.name;
      this.formulario = new FormGroup({
        Id: new FormControl(resultado.Id),
        name: new FormControl(resultado.name,[Validators.required, Validators.maxLength(50)]),
        descricao: new FormControl(resultado.descricao,[Validators.required, Validators.maxLength(50)]),
      });

    });
  }

  get propriedade(){
    return this.formulario.controls;
  }


  EnviarFormulario():void {
    this.erros = [];
    const funcao = this.formulario.value;
    funcao.id = this.funcaoId;    
    this.funcoesService.AtualizarFuncao(this.funcaoId,funcao ).subscribe(resultado =>{
      this.router.navigate(['Funcoes/listagemfuncoes']);
      this.snackBar.open(resultado.mensagem, '',
        {
          duration: 2000,
          horizontalPosition: 'center',
          verticalPosition: 'top'
        });

    },(err) => {
      if (err.status ==400)
      {
        for(const campo in err.error.errors){
          if (err.error.errors.hasOwnProperty(campo))
          {
            this.erros.push(err.error.errors[campo]);
          }
        }
      }
    });
  }

  VoltarListagem():void {
    this.router.navigate(['Funcoes/listagemfuncoes']);
  }
  

}
