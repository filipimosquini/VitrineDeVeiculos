import { Injectable } from "@angular/core";

import { LocalStorageUtils } from "src/app/utils/localstorage";

@Injectable()
export class BaseGuard {

  localStorageUtils = new LocalStorageUtils();

  canLoad() {
    return this.localStorageUtils.obterTokenUsuario();
  }
}
