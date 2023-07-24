import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { VeiculoComponent } from "./veiculo.component";

@NgModule({
  declarations: [
    VeiculoComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    VeiculoComponent
  ]
})
export class VeiculoModule { }
