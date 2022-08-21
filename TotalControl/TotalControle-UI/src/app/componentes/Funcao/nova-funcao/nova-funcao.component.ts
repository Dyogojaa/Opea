import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { FuncoesService } from 'src/app/services/funcoes.service';

@Component({
  selector: 'app-nova-funcao',
  templateUrl: './nova-funcao.component.html',
  styleUrls: ['../listagem-funcoes/listagem-funcoes.component.css']
})
export class NovaFuncaoComponent implements OnInit {


  formulario: any;
  erros: string[];

  constructor(private router: Router, 
              private funcoesServices: FuncoesService,
              private snakBar:MatSnackBar) { }

  ngOnInit(): void {
    this.erros =[];
    this.formulario = new FormGroup({
      name: new FormControl(null, [Validators.required, Validators.maxLength(50)]),
      descricao: new FormControl(null, [Validators.required, Validators.maxLength(50)])
    });
  }

  get propriedade(){
    return this.formulario.controls;
  }

  EnviarFormulario(): void {
    const funcao = this.formulario.value;
    this.erros = [];
    this.funcoesServices.NovaFuncao(funcao).subscribe(resultado => {
      this.router.navigate(['Funcoes/listagemfuncoes']);
      this.snakBar.open(resultado.mensagem, '', {
        duration:2000,
        horizontalPosition: 'center',
        verticalPosition: 'top'
      }); 
    }, err => {
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
