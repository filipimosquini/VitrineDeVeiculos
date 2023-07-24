import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { FormBaseComponent } from 'src/app/base/form-base-component';
import { UsuarioService } from '../services/usuario.service';
import { Usuario } from '../models/usuario';

import { ToastrService } from 'ngx-toastr';
import { CustomValidators } from '@narik/custom-validators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: []
})
export class LoginComponent extends FormBaseComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  loginForm: FormGroup;
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

    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, CustomValidators.email]],
      senha: senha
    });  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.loginForm);
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
    };

    super.configurarMensagensValidacaoBase(this.validationMessages);
  }

  private validaSeFormularioEstaPreencidoCorretamente() {
    return this.loginForm?.dirty && this.loginForm?.valid;
  }

  private processarRequisicaoComSucesso(response: any){
    this.loginForm.reset();
    this.errors = [];

    this.service.localStorage.salvarDadosLocaisUsuario(response);

    let toast = this.toastr.success("Login realizado com Sucesso!, Bem vindo!")

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

  login(){
    if(this.validaSeFormularioEstaPreencidoCorretamente()){
      this.usuario = Object.assign({}, this.usuario, this.loginForm.value);

      this.service.login(this.usuario)
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
