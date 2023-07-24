import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Usuario } from "../models/usuario";
import { Observable, catchError, map } from "rxjs";
import { BaseService } from "src/app/base/base.service";

@Injectable()
export class UsuarioService extends BaseService {

  constructor(private http: HttpClient){
    super();
  }

  cadastrar(usuario: Usuario) : Observable<Usuario> {
    return this.http
      .post(this.urlServiceV1+'usuarios/cadastrar', usuario)
      .pipe(
        map(this.obterDadosDoResponse),
        catchError(this.tratarErrosDoServidor))
  }

  login(usuario: Usuario){

  }
}
