import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, map } from "rxjs";

import { BaseService } from "src/app/base/base.service";
import { Veiculo } from "../models/veiculo";
import { Marca } from "../models/marca";
import { Modelo } from "../models/modelo";
import { FiltroVeiculo } from "src/app/vitrine/models/filtroVeiculo";

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
        catchError(this.tratarErrosDoServidor));
  }

  listarComFiltros(filtro: FiltroVeiculo) : Observable<Veiculo[]>{
    return this.http
      .get(this.urlApi+'veiculos', { params: super.ObterParametrosDeObjeto(filtro) })
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }

  listarMarcas() : Observable<Marca[]>{
    return this.http
      .get(this.urlApi+'veiculos/marcas', super.ObterAuthHeaderJson())
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }

  listarModelos(marcaId: string) : Observable<Modelo[]>{
    return this.http
      .get(this.urlApi+'veiculos/modelos/'+marcaId, super.ObterAuthHeaderJson())
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }

  obter(id) : Observable<Veiculo>{
    return this.http
      .get(this.urlApi+'veiculos/'+id, super.ObterAuthHeaderJson())
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }

  cadastrar(veiculo: Veiculo) : Observable<Veiculo> {
    return this.http
      .post(this.urlApi+'veiculos', veiculo, super.ObterAuthHeaderJson())
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }

  editar(veiculo: Veiculo) : Observable<Veiculo> {
    return this.http
      .put(this.urlApi+'veiculos', veiculo, super.ObterAuthHeaderJson())
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }

  excluir(veiculo: Veiculo) : Observable<Veiculo> {
    return this.http
      .delete(this.urlApi+'veiculos/'+veiculo.id, super.ObterAuthHeaderJson())
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }
}
