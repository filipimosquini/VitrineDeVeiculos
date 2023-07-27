import { Injectable } from "@angular/core";

import { LocalStorageUtils } from "src/app/utils/localstorage";

@Injectable()
export class AppGuard {

  localStorageUtils = new LocalStorageUtils();

  canLoad() {
    return this.localStorageUtils.obterTokenUsuario();
  }
}
