import { Injectable } from "@angular/core";

import { CadastroComponent } from "../cadastro/cadastro.component";
import { ActivatedRouteSnapshot, Router } from "@angular/router";
import { BaseGuard } from "src/app/base/base.guard";

@Injectable()
export class VeiculoGuard extends BaseGuard {

  constructor(protected override router: Router){
    super(router);
  }

  canDeactivate(component: CadastroComponent) {
    if(component.mudancasNaoSalvas) {
      return window.confirm('Tem certeza que deseja abandonar o preenchimento do formulario?');
    }

    return true;
  }

  canActivate(activatedRouteSnapshot: ActivatedRouteSnapshot) {
    return super.validarClaims(activatedRouteSnapshot);
  }
}
