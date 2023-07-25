import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, map } from "rxjs";

import { BaseService } from "src/app/base/base.service";
import { Veiculo } from "../models/veiculo";

@Injectable()
export class VeiculoService extends BaseService {

  constructor(private http: HttpClient){
    super();
  }

  cadastrar(veiculo: Veiculo) : Observable<Veiculo> {
    return this.http
      .post(this.urlApi+'veiculos', veiculo)
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }
}
