import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './navegacao/not-found/not-found.component';
import { ListarComponent } from './vitrine/listar/listar.component';
import { BaseGuard } from './base/base.guard';

const routes: Routes = [
  { path: '', redirectTo: '/vitrine', pathMatch: 'full' },
  { path: 'vitrine', component: ListarComponent },
  { path: 'usuarios', loadChildren: () => import('./usuarios/usuario.module').then(x => x.UsuarioModule) },
  { path: 'veiculos', loadChildren: () => import('./veiculos/veiculo.module').then(x => x.VeiculoModule), canLoad: [BaseGuard] },

  { path: 'nao-encontrado', component: NotFoundComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
