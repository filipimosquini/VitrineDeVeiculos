import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './navegacao/not-found/not-found.component';
import { VeiculoComponent } from './veiculos/veiculo.component';

const routes: Routes = [
  { path: '', redirectTo: '/vitrine', pathMatch: 'full' },
  { path: 'vitrine', component: VeiculoComponent },
  { path: 'usuarios', loadChildren: () => import('./usuario/usuario.module').then(x => x.UsuarioModule) },

  { path: 'nao-encontrado', component: NotFoundComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
