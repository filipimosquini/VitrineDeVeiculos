import { HttpErrorResponse, HttpHeaders, HttpParams } from "@angular/common/http";
import { throwError } from "rxjs";
import { LocalStorageUtils } from "../utils/localstorage";
import { environment } from "src/environments/enviroment";

export abstract class BaseService {

  public localStorage = new LocalStorageUtils();
  protected urlApi: string = environment.urlApi;

  protected ObterParametrosDeObjeto(filtro: any){
    let params = new HttpParams();
    for (const key in filtro) {
      if (filtro.hasOwnProperty(key)) {
        if(filtro[key]){
          params = params.set(key, filtro[key]);
        }
      }
    }

    return params;
  }

  protected ObterHeaderJson() {
    return {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };
}

protected ObterAuthHeaderJson() {
    return {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${this.localStorage.obterTokenUsuario()}`
        })
    };
}
  protected obterDadosDoResponse(response: any) {
    return response.data || {};
  }

  protected tratarErrosDoServidor(response: Response | any) {
    let customError: string[] = [];
    let customResponse = { error: { errors: [] }}

    if (response instanceof HttpErrorResponse) {

        if (response.statusText === "Unknown Error") {
            customError.push("Ocorreu um erro desconhecido");
            response.error.errors = customError;
        }
    }
    if (response.status === 500) {
        customError.push("Ocorreu um erro no processamento, tente novamente mais tarde ou contate o nosso suporte.");

        // Erros do tipo 500 não possuem uma lista de erros
        // A lista de erros do HttpErrorResponse é readonly
        customResponse.error.errors = customError;
        return throwError(() => customResponse);
    }

    console.error(response);
    return throwError(() => response);
  }
}
