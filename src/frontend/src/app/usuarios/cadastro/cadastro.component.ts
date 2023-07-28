import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';

import { Usuario } from '../models/usuario';
import { UsuarioService } from '../services/usuario.service';

import { FormBaseComponent } from 'src/app/base/form-base-component';
import { CustomValidators } from '@narik/custom-validators';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent extends FormBaseComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  cadastroForm: FormGroup;
  usuario : Usuario;

  constructor(private formBuilder: FormBuilder,
              private service: UsuarioService,
              private router: Router,
              private toastr: ToastrService) {

    super();

    this.configurarMensagensDeValidacaoDoFormulario();
  }

  ngOnInit(): void {

    let senha = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15])]);
    let confirmarSenha = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15]), CustomValidators.equalTo(senha)]);

    this.cadastroForm = this.formBuilder.group({
      email: ['', [Validators.required, CustomValidators.email]],
      senha: senha,
      confirmarSenha: confirmarSenha
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.cadastroForm);
  }

  private configurarMensagensDeValidacaoDoFormulario() : void{
    this.validationMessages = {
      email: {
        required: 'Informe o e-mail',
        email: 'Email inválido'
      },
      senha: {
        required: 'Informe a senha',
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres'
      },
      confirmarSenha: {
        required: 'Informe a senha novamente',
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres',
        equalTo: 'As senhas não conferem'
      }
    };

    super.configurarMensagensValidacaoBase(this.validationMessages);
  }

  private validaSeFormularioEstaPreencidoCorretamente() {
    return this.cadastroForm?.dirty && this.cadastroForm?.valid;
  }

  private processarRequisicaoComSucesso(response: any){
    this.cadastroForm.reset();
    this.errors = [];

    this.service.localStorage.salvarDadosLocaisUsuario(response);

    let toast = this.toastr.success("Cadastro realizado com sucesso", "Bem vindo!")

    if(toast){
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/vitrine']);
      });
    }
  }

  private processarRequisicaoComFalha(fail: any){
    this.errors = fail.error.errors;
    this.toastr.error("Ocorreu um erro", "Erro ao realizar esta operação.")
  }

  cadastrar(){
    if(this.validaSeFormularioEstaPreencidoCorretamente()){
      this.usuario = Object.assign({}, this.usuario, this.cadastroForm.value);

      this.service.cadastrar(this.usuario)
        .subscribe({
          next: (v) => {
            this.processarRequisicaoComSucesso(v)
          },
          error: (e) => {
            this.processarRequisicaoComFalha(e)
          },
          complete: () => console.info('complete')
        });

      this.atualizarFlagMudancasNaoSalvasParaFalso();
    }
  }
}
