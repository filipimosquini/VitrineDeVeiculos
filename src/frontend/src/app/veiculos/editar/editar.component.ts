import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBaseComponent } from 'src/app/base/form-base-component';
import { ToastrService } from 'ngx-toastr';

import { Veiculo } from '../models/veiculo';
import { Marca } from '../models/marca';
import { Modelo } from '../models/modelo';
import { VeiculoService } from '../services/veiculo.service';
import { environment } from 'src/enviroments/enviroment';
import { Dimensions, ImageCroppedEvent, ImageTransform } from 'ngx-image-cropper';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: []
})
export class EditarComponent  extends FormBaseComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  imagens: string = environment.imagensUrl;

  imageChangedEvent: any = '';
  croppedImage: any = '';
  canvasRotation = 0;
  rotation = 0;
  scale = 1;
  showCropper = false;
  containWithinAspectRatio = false;
  transform: ImageTransform = {};
  imagemNome: string;

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
      modeloId: ['', [Validators.required]],
      uploadDaImagem: ['', []],
    });

    this.veiculo = this.route.snapshot.data['veiculo'];

    this.listarModelos(this.veiculo.marca.id);

    this.edicaoForm.patchValue({
      id: this.veiculo.id,
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

  private processarRequisicaoComSucesso(){
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

  private existeImageParaAtualizar(){
    return this.croppedImage && this.imagemNome
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

      if(this.existeImageParaAtualizar()){
        this.veiculo.uploadDaImagem = this.croppedImage.split(',')[1];
        this.veiculo.nomeDaImagem = this.imagemNome;
      }

      this.service.editar(this.veiculo)
        .subscribe({
          next: (v) => {
            this.processarRequisicaoComSucesso()
          },
          error: (e) => {
            this.processarRequisicaoComFalha(e)
          },
          complete: () => { }
        });

      this.atualizarFlagMudancasNaoSalvasParaFalso();
    }
  }

  //#region Imagens

  fileChangeEvent(event: any): void {
    this.imageChangedEvent = event;
    this.imagemNome = event.currentTarget.files[0].name;
  }

  imageCropped(event: ImageCroppedEvent) {
    this.croppedImage = event.base64;
  }

  imageLoaded() {
    this.showCropper = true;
  }

  cropperReady(sourceImageDimensions: Dimensions) {
    console.log('Cropper ready', sourceImageDimensions);
  }

  loadImageFailed() {
    this.errors.push('O formato do arquivo ' + this.imagemNome + ' não é aceito.');
  }

  //#endregion

}
