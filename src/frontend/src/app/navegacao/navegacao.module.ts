import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { FooterComponent } from "./footer/footer.component";
import { MenuComponent } from "./menu/menu.component";
import { NotFoundComponent } from "./not-found/not-found.component";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { UsuarioLogadoComponent } from './usuario-logado/usuario-logado.component';

@NgModule({
  declarations: [
    MenuComponent,
    FooterComponent,
    NotFoundComponent,
    UsuarioLogadoComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    NgbModule
  ],
  exports: [
    MenuComponent,
    FooterComponent,
    NotFoundComponent,
    UsuarioLogadoComponent
  ]
})
export class NavegacaoModule { }
