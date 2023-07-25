import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { CadastroComponent } from './cadastro/cadastro.component';
import { LoginComponent } from './login/login.component';
import { UsuarioRoutingModule } from './usuario.route';
import { UsuarioAppComponent } from './usuario.app.component';
import { UsuarioGuard } from './services/usuario.guard';
import { NarikCustomValidatorsModule } from '@narik/custom-validators';
import { UsuarioService } from './services/usuario.service';

@NgModule({
  declarations: [
    UsuarioAppComponent,
    CadastroComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    UsuarioRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NarikCustomValidatorsModule
  ],
  providers:[
    UsuarioService,
    UsuarioGuard
  ]
})
export class UsuarioModule { }
