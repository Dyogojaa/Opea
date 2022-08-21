import { Component, OnInit, resolveForwardRef } from '@angular/core';
import { Tipo } from 'src/app/models/tipos';
import TiposService from 'src/app/services/tipos.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CategoriasService } from 'src/app/services/categorias.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-nova-categoria',
  templateUrl: './nova-categoria.component.html',
  styleUrls: ['../listagem-categorias/listagem-categorias.component.css']
})
export class NovaCategoriaComponent implements OnInit {

  formulario: any;
  tipos: Tipo[];
  erros:string[]; //Variaveis de Erros para receber as Mensagens do BackEnd

  constructor(private tipoService: TiposService, private categoriaServico: CategoriasService,
    private router: Router,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.erros = [];
    this.tipoService.PegarTodos().subscribe(resultado => {
      this.tipos = resultado;
      console.log(resultado);
    });

    this.formulario = new FormGroup({
      //Após atribuir o nome ao Controle do Formulário, também utilizamos o Validators para Validar no FrontEnd as Informações
      nome: new FormControl(null, [Validators.required,Validators.maxLength(50)]),
      icone: new FormControl(null,[Validators.required, Validators.maxLength(15)]),
      tipoId: new FormControl(null, [Validators.required])

    });
  }

  get propriedade(){
    return this.formulario.controls;
  }

  EnviarFormulario():void{
    const categoria = this.formulario.value;
    this.erros = [];
    this.categoriaServico.NovaCategoria(categoria).subscribe((resultado) => {
      this.router.navigate(['Categorias/listagemcategorias']);    
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
    this.router.navigate(['Categorias/listagemcategorias']);      
  }

}
