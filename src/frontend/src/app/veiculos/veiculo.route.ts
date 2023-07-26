import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CadastroComponent } from './cadastro/cadastro.component';
import { VeiculoGuard } from './services/veiculo.guard';
import { VeiculoAppComponent } from './veiculo.app.component';
import { ListarComponent } from './listar/listar.component';
import { EditarComponent } from './editar/editar.component';
import { VeiculoResolve } from './services/veiculo.resolve';

const contaRouterConfig: Routes = [
    {
        path: '', component: VeiculoAppComponent,
        children: [
            { path: '', component: ListarComponent, canActivate: [VeiculoGuard], },
            { path: 'listar', component: ListarComponent, canActivate: [VeiculoGuard], },
            { path: 'cadastro', component: CadastroComponent, canActivate: [VeiculoGuard], canDeactivate: [VeiculoGuard] },
            { path: 'editar/:id', component: EditarComponent, canActivate: [VeiculoGuard], canDeactivate: [VeiculoGuard], resolve: { veiculo: VeiculoResolve } },
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
