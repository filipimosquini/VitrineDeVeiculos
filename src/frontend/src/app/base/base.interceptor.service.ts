import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

import { Observable, catchError, throwError } from "rxjs";

import { LocalStorageUtils } from "../utils/localstorage";

@Injectable()
export class BaseInterceptor implements HttpInterceptor {

    constructor(private router: Router) { }

    localStorageUtil = new LocalStorageUtils();

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        return next.handle(request).pipe(catchError(error => {

            if (error instanceof HttpErrorResponse) {

                if (error.status === 401) {
                    this.localStorageUtil.limparDadosLocaisUsuario();
                    this.router.navigate(['/usuarios/login'], { queryParams: { returnUrl: this.router.url }});
                }
                if (error.status === 403) {
                  this.router.navigate(['/acesso-negado']);
                }
            }

            return throwError(() =>error);
        }));
    }

}
