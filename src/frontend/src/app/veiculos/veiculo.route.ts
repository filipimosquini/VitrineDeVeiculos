import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CadastroComponent } from './cadastro/cadastro.component';
import { VeiculoGuard } from './services/veiculo.guard';
import { VeiculoAppComponent } from './veiculo.app.component';
import { ListarComponent } from './listar/listar.component';
import { EditarComponent } from './editar/editar.component';
import { VeiculoResolve } from './services/veiculo.resolve';
import { ExcluirComponent } from './excluir/excluir.component';

const contaRouterConfig: Routes = [
    {
        path: '', component: VeiculoAppComponent,
        children: [
            {
              path: '',
              component: ListarComponent,
              canActivate: [VeiculoGuard],
            },
            {
              path: 'listar',
              component: ListarComponent,
              canActivate: [VeiculoGuard],
            },
            {
              path: 'cadastro',
              component: CadastroComponent,
              canActivate: [VeiculoGuard],
              canDeactivate: [VeiculoGuard],
              data: [{ claim: [{ nome: 'Veiculo', valor: 'Adicionar' }, { nome: 'Marca', valor: 'Listar' }, { nome: 'Modelo', valor: 'Listar' }] }],
            },
            {
              path: 'editar/:id',
              component: EditarComponent,
              canActivate: [VeiculoGuard],
              canDeactivate: [VeiculoGuard],
              resolve: { veiculo: VeiculoResolve },
              data: [{ claim: [{ nome: 'Veiculo', valor: 'Atualizar' }, { nome: 'Marca', valor: 'Listar' }, { nome: 'Modelo', valor: 'Listar' }] }],
            },
            {
              path: 'excluir/:id',
              component: ExcluirComponent,
              canActivate: [VeiculoGuard],
              canDeactivate: [VeiculoGuard],
              resolve: { veiculo: VeiculoResolve },
              data: [{ claim: { nome: 'Veiculo', valor: 'Excluir' } }],
            },
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(contaRouterConfig)
    ],
    exports: [RouterModule]
})
export class VeiculoRoutingModule { }
