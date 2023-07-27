import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

import { BaseGuard } from "./base/base.guard";
import { LocalStorageUtils } from "./utils/localstorage";

@Injectable()
export class AppGuard extends BaseGuard {

  override localStorageUtils = new LocalStorageUtils();

  constructor(protected override router: Router) { super(router); }

  canLoad() {
    return this.localStorageUtils.obterTokenUsuario();
  }
}
