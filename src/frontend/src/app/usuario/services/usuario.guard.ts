import { Injectable } from "@angular/core";
import { CanDeactivate, CanActivate, Router } from "@angular/router";
import { CadastroComponent } from "../cadastro/cadastro.component";

@Injectable()
export class UsuarioGuard implements CanDeactivate<CadastroComponent>, CanActivate {

  constructor(private router: Router){}

  canDeactivate(component: CadastroComponent) {
    return true
  }

  canActivate() {
    return true;
  }
}
