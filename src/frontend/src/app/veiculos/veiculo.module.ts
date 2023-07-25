import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { NarikCustomValidatorsModule } from "@narik/custom-validators";

import { VeiculoAppComponent } from "./veiculo.app.component";
import { VeiculoRoutingModule } from "./veiculo.route";
import { VeiculoGuard } from "./services/veiculo.guard";
import { VeiculoService } from "./services/veiculo.service";
import { CadastroComponent } from './cadastro/cadastro.component';
import { ListarComponent } from './listar/listar.component';

@NgModule({
  declarations: [
    VeiculoAppComponent,
    CadastroComponent,
    ListarComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NarikCustomValidatorsModule,
    VeiculoRoutingModule,
  ],
  exports: [
    ListarComponent
  ],
  providers: [
    VeiculoGuard,
    VeiculoService
  ]
})
export class VeiculoModule { }
