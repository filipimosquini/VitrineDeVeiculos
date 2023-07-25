import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CadastroComponent } from './cadastro/cadastro.component';
import { VeiculoGuard } from './services/veiculo.guard';
import { VeiculoAppComponent } from './veiculo.app.component';

const contaRouterConfig: Routes = [
    {
        path: '', component: VeiculoAppComponent,
        children: [
            { path: 'cadastro', component: CadastroComponent, canActivate: [VeiculoGuard], canDeactivate: [VeiculoGuard] },
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
