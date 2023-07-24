import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';

import { Usuario } from '../models/usuario';
import { UsuarioService } from '../services/usuario.service';

import { FormBaseComponent } from 'src/app/base/form-base-component';
import { CustomValidators } from '@narik/custom-validators';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: []
})
export class CadastroComponent extends FormBaseComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  cadastroForm: FormGroup;
  usuario : Usuario;

  constructor(private formBuilder: FormBuilder,
              private service: UsuarioService) {

    super();

    this.configurarMensagensDeValidacaoDoFormulario();
  }

  ngOnInit(): void {

    let senha = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15])]);
    let confirmarSenha = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15]), CustomValidators.equalTo(senha)]);

    this.cadastroForm = this.formBuilder.group({
      email: ['', Validators.required, Validators.email],
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
      password: {
        required: 'Informe a senha',
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres'
      },
      confirmPassword: {
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
  }

  private processarRequisicaoComFalha(fail: any){
    this.errors = fail.error.errors;
  }

  cadastrar(){
    if(this.validaSeFormularioEstaPreencidoCorretamente()){
      this.usuario = Object.assign({}, this.usuario, this.cadastroForm.value);

      this.service.cadastrar(this.usuario)
        .subscribe({
          next: (v) => this.processarRequisicaoComSucesso,
          error: (e) => this.processarRequisicaoComFalha,
          complete: () => console.info('complete')
      });
    }
  }
}
