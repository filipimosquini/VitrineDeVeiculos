import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { NarikCustomValidatorsModule } from "@narik/custom-validators";
import { NgxMaskModule } from "ngx-mask";

import { VeiculoAppComponent } from "./veiculo.app.component";
import { VeiculoRoutingModule } from "./veiculo.route";
import { VeiculoGuard } from "./services/veiculo.guard";
import { VeiculoService } from "./services/veiculo.service";
import { CadastroComponent } from './cadastro/cadastro.component';
import { ListarComponent } from './listar/listar.component';
import { EditarComponent } from './editar/editar.component';
import { VeiculoResolve } from "./services/veiculo.resolve";
import { ExcluirComponent } from './excluir/excluir.component';
import { ImageCropperModule } from "ngx-image-cropper";
import { CurrencyMaskModule } from "ng2-currency-mask";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";

@NgModule({
  declarations: [
    VeiculoAppComponent,
    CadastroComponent,
    ListarComponent,
    EditarComponent,
    ExcluirComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    NarikCustomValidatorsModule,
    VeiculoRoutingModule,
    NgxMaskModule.forChild(),
    ImageCropperModule,
    CurrencyMaskModule,
    NgbModule
  ],
  providers: [
    VeiculoGuard,
    VeiculoService,
    VeiculoResolve
  ]
})

export class VeiculoModule {
  static paraVitrine(){
    return {
      ngModule: VeiculoModule,
      providers: [
        VeiculoService
      ]
    }
  }
 }
