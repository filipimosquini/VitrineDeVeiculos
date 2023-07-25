import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { NarikCustomValidatorsModule } from '@narik/custom-validators';

import { UsuarioAppComponent } from './usuario.app.component';
import { UsuarioRoutingModule } from './usuario.route';
import { UsuarioGuard } from './services/usuario.guard';
import { UsuarioService } from './services/usuario.service';
import { CadastroComponent } from './cadastro/cadastro.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    UsuarioAppComponent,
    CadastroComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NarikCustomValidatorsModule,
    UsuarioRoutingModule,
  ],
  providers:[
    UsuarioService,
    UsuarioGuard
  ]
})
export class UsuarioModule { }
