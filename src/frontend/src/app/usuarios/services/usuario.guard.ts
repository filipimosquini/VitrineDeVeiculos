import { Injectable } from "@angular/core";

import { CadastroComponent } from "../cadastro/cadastro.component";
import { LocalStorageUtils } from "src/app/utils/localstorage";
import { Router } from "@angular/router";
import { BaseGuard } from "src/app/base/base.guard";

@Injectable()
export class UsuarioGuard extends BaseGuard {

  override localStorageUtils = new LocalStorageUtils();

  constructor(protected override router: Router){
    super(router);
  }

  canDeactivate(component: CadastroComponent) {
    if(component.mudancasNaoSalvas) {
      return window.confirm('Tem certeza que deseja abandonar o preenchimento do formulario?');
    }

    return true;
  }

  canActivate() {
    if(this.localStorageUtils.obterTokenUsuario()){
      this.router.navigate(['/vitrine']);
    }

    return true;
  }
}
