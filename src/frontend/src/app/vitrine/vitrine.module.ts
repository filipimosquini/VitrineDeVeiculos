import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CurrencyMaskModule } from 'ng2-currency-mask';

import { ListarComponent } from './listar/listar.component';
import { VeiculoModule } from '../veiculos/veiculo.module';

@NgModule({
  declarations: [
    ListarComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    CurrencyMaskModule,
    VeiculoModule.paraVitrine(),
  ],
  providers:[]
})
export class VitrineModule { }
