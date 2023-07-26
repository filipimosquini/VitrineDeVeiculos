import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormBaseComponent } from 'src/app/base/form-base-component';

import { Veiculo } from '../models/veiculo';
import { VeiculoService } from '../services/veiculo.service';
import { Marca } from '../models/marca';
import { Modelo } from '../models/modelo';


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
  marcas: Marca[];
  modelos: Modelo[];

  constructor(private formBuilder: FormBuilder,
              private service: VeiculoService,
              private router: Router,
              private toastr: ToastrService) {

    super();

    this.configurarMensagensDeValidacaoDoFormulario();
  }

  ngOnInit(): void {

    this.cadastroForm = this.formBuilder.group({
      nome: ['', [Validators.required]],
      valor: ['', [Validators.required]],
      marcaId: ['', [Validators.required]],
      modeloId: ['', [Validators.required]]
    });

    this.listarMarcas();
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.cadastroForm);
  }

  private configurarMensagensDeValidacaoDoFormulario() : void{
    this.validationMessages = {
      nome: {
        required: 'Informe um nome',
      },
      valor: {
        required: 'Informe um valor',
      },
      marcaId: {
        required: 'Informe a marca',
      },
      modeloId: {
        required: 'Informe o modelo',
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

    let toast = this.toastr.success("Veículo cadastrado com sucesso", "Dados cadastrados com sucesso");

    if(toast){
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/veiculos/listar']);
      });
    }
  }

  private processarRequisicaoComFalha(fail: any){
    this.errors = fail.error.errors;
    this.toastr.error("Ocorreu um erro", "Erro ao realizar esta operação.")
  }

  listarMarcas(){
    this.service.listarMarcas()
    .subscribe({
      next: (marcas) => { this.marcas = marcas },
      error: (e) => {
        this.marcas = [];
        this.processarRequisicaoComFalha(e);
      },
      complete: () => {}
    });
  }

  listarModelos(marcaId: string){
    this.service.listarModelos(marcaId)
    .subscribe({
      next: (modelos) => { this.modelos = modelos },
      error: (e) => {
        this.modelos = [];
        this.processarRequisicaoComFalha(e);
      },
      complete: () => {}
    });
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
