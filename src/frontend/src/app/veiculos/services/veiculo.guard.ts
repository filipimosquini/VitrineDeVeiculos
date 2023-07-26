import { Injectable } from "@angular/core";

import { CadastroComponent } from "../cadastro/cadastro.component";
import { LocalStorageUtils } from "src/app/utils/localstorage";
import { Router } from "@angular/router";

@Injectable()
export class VeiculoGuard {

  localStorageUtils = new LocalStorageUtils();

  constructor(private router: Router){}

  canDeactivate(component: CadastroComponent) {
    if(component.mudancasNaoSalvas) {
      return window.confirm('Tem certeza que deseja abandonar o preenchimento do formulario?');
    }

    return true;
  }

  canActivate() {
    if(!this.localStorageUtils.obterTokenUsuario()){
      this.router.navigate(['/usuarios/login']);
    }

    return true;
  }
}
