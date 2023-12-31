import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsuarioAppComponent } from './usuario.app.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { LoginComponent } from './login/login.component';
import { UsuarioGuard } from './services/usuario.guard';

const usuarioRouterConfig: Routes = [
    {
        path: '', component: UsuarioAppComponent,
        children: [
            { path: 'cadastro', component: CadastroComponent, canActivate: [UsuarioGuard], canDeactivate: [UsuarioGuard] },
            { path: 'login', component: LoginComponent, canActivate: [UsuarioGuard] }
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(usuarioRouterConfig)
    ],
    exports: [RouterModule]
})
export class UsuarioRoutingModule { }
