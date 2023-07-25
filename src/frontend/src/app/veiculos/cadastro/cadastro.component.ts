import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormBaseComponent } from 'src/app/base/form-base-component';

import { Veiculo } from '../models/veiculo';
import { VeiculoService } from '../services/veiculo.service';


@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: []
})
export class CadastroComponent extends FormBaseComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  cadastroForm: FormGroup;
  veiculo : Veiculo;

  constructor(private formBuilder: FormBuilder,
              private service: VeiculoService,
              private router: Router,
              private toastr: ToastrService) {

    super();
  }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.cadastroForm);
  }

  private validaSeFormularioEstaPreencidoCorretamente() {
    return this.cadastroForm?.dirty && this.cadastroForm?.valid;
  }

  private processarRequisicaoComSucesso(response: any){
    this.cadastroForm.reset();
    this.errors = [];

    let toast = this.toastr.success("Sucesso", "Veículo cadastrado com sucesso")

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
      this.veiculo = Object.assign({}, this.veiculo, this.cadastroForm.value);

      this.service.cadastrar(this.veiculo)
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
