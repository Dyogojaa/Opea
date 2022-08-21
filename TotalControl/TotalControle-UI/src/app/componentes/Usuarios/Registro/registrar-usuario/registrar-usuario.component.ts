import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { DadosRegistro } from 'src/app/models/DadosRegistro';
import { UsuariosService } from 'src/app/services/usuarios.service';

@Component({
  selector: 'app-registrar-usuario',
  templateUrl: './registrar-usuario.component.html',
  styleUrls: ['./registrar-usuario.component.css']
})
export class RegistrarUsuarioComponent implements OnInit {

  formulario: any;
  foto : File | null;
  erros: string[];



  constructor(private usuariosServices : UsuariosService,
              private router : Router,
              private snakBar:MatSnackBar) { }

  ngOnInit(): void {
    this.erros = [];    
    this.formulario = new FormGroup({
      nomeUsuario: new FormControl(null, [Validators.required, Validators.minLength(6),Validators.maxLength(50)]),
      cpf: new FormControl(null, [Validators.required, Validators.minLength(11),Validators.maxLength(20)]),
      profissao: new FormControl(null, [Validators.required, Validators.minLength(10),Validators.maxLength(30)]),
      foto: new FormControl(null, [Validators.required]),
      email: new FormControl(null, [Validators.required,Validators.email, Validators.minLength(10),Validators.maxLength(50)]),
      senha: new FormControl(null, [Validators.required,Validators.minLength(6),Validators.maxLength(15)]),
    });
    
  }

  get propriedade(){
    return this.formulario.controls;
  }

  SelecionarFoto(fileInput: any): void {        
    this.foto = fileInput.target.files[0] as File;
    const reader = new FileReader();
    reader.onload = function (e: any) {
      document.getElementById('foto')?.removeAttribute('hidden');
      document.getElementById('foto')?.setAttribute('src', e.target.result);
    };

    reader.readAsDataURL(this.foto);
  }

  EnviarFormulario(): void {    
    const usuario = this.formulario.value;
    const formData : FormData = new FormData();
    this.erros = [];

    //Verifica se a Foto Selecionada não está vazia    
    if (this.foto !=null)    
    {
      //Atribui a variavel formData a Foto com nome do arquivo, a foto e nome da foto  
      formData.append('file', this.foto, this.foto.name);
    }
    this.usuariosServices.SalvarFoto(formData).subscribe(resultado =>{
        const dadosRegistro : DadosRegistro = new DadosRegistro();
        dadosRegistro.nomeUsuario = usuario.nomeUsuario;
        dadosRegistro.cpf = usuario.cpf;
        dadosRegistro.foto = resultado.foto;
        dadosRegistro.profissao = usuario.profissao;
        dadosRegistro.email = usuario.email;
        dadosRegistro.senha = usuario.senha;

        this.usuariosServices.RegistrarUsuario(dadosRegistro).subscribe(dados => {      
          const emailUsuarioLogado = dados.emailUsuarioLogado;
          localStorage.setItem('EmailUsuarioLogado', emailUsuarioLogado);
          this.router.navigate(['Usuarios/loginusuario']);              
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
    });
  }  

 
}
