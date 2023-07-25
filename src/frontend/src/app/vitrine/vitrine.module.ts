import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListarComponent } from './listar/listar.component';
import { VeiculoModule } from '../veiculos/veiculo.module';

@NgModule({
  declarations: [
    ListarComponent
  ],
  imports: [
    CommonModule,
    VeiculoModule.paraVitrine()
  ],
  providers:[]
})
export class VitrineModule { }
