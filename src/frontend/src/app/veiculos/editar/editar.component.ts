import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBaseComponent } from 'src/app/base/form-base-component';
import { ToastrService } from 'ngx-toastr';

import { Veiculo } from '../models/veiculo';
import { Marca } from '../models/marca';
import { Modelo } from '../models/modelo';
import { VeiculoService } from '../services/veiculo.service';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: []
})
export class EditarComponent  extends FormBaseComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  edicaoForm: FormGroup;
  veiculo : Veiculo;
  marcas: Marca[];
  modelos: Modelo[];

  constructor(private formBuilder: FormBuilder,
              private service: VeiculoService,
              private router: Router,
              private route: ActivatedRoute,
              private toastr: ToastrService) {

    super();

    this.configurarMensagensDeValidacaoDoFormulario();
  }

  ngOnInit(): void {

    this.listarMarcas();

    this.edicaoForm = this.formBuilder.group({
      nome: ['', [Validators.required]],
      valor: ['', [Validators.required]],
      marcaId: ['', [Validators.required]],
      modeloId: ['', [Validators.required]]
    });

    this.veiculo = this.route.snapshot.data['veiculo'];

    this.listarModelos(this.veiculo.marca.id);

    this.edicaoForm.patchValue({
      id: this.veiculo.id,
      //imagem: this.veiculo.imagem,
      nome: this.veiculo.nome,
      valor: this.veiculo.valor,
      marcaId: this.veiculo.marca.id,
      modeloId: this.veiculo.modelo.id,
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.edicaoForm);
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
    return this.edicaoForm?.dirty && this.edicaoForm?.valid;
  }

  private processarRequisicaoComSucesso(response: any){
    this.edicaoForm.reset();
    this.errors = [];

    let toast = this.toastr.success("Veículo alterado com sucesso", "Dados alterados com sucesso");

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

  editar(){
    if(this.validaSeFormularioEstaPreencidoCorretamente()){
      this.veiculo = Object.assign({}, this.veiculo, this.edicaoForm.value);

      this.service.editar(this.veiculo)
        .subscribe({
          next: (v) => {
            this.processarRequisicaoComSucesso(v)
          },
          error: (e) => {
            this.processarRequisicaoComFalha(e)
          },
          complete: () => { }
        });

      this.atualizarFlagMudancasNaoSalvasParaFalso();
    }
  }
}

