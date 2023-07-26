import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, map } from "rxjs";

import { BaseService } from "src/app/base/base.service";
import { Veiculo } from "../models/veiculo";
import { Marca } from "../models/marca";
import { Modelo } from "../models/modelo";

@Injectable()
export class VeiculoService extends BaseService {

  constructor(private http: HttpClient){
    super();
  }

  listar() : Observable<Veiculo[]>{
    return this.http
      .get(this.urlApi+'veiculos')
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }

  listarMarcas() : Observable<Marca[]>{
    return this.http
      .get(this.urlApi+'veiculos/marcas')
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }

  listarModelos(marcaId: string) : Observable<Modelo[]>{
    return this.http
      .get(this.urlApi+'veiculos/modelos/'+marcaId)
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }

  obter(id) : Observable<Veiculo>{
    return this.http
      .get(this.urlApi+'veiculos/'+id)
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }

  cadastrar(veiculo: Veiculo) : Observable<Veiculo> {
    return this.http
      .post(this.urlApi+'veiculos', veiculo)
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }

  editar(veiculo: Veiculo) : Observable<Veiculo> {
    return this.http
      .put(this.urlApi+'veiculos', veiculo)
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }
}
