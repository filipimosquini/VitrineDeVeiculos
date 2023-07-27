import { Router, ActivatedRouteSnapshot } from '@angular/router';
import { LocalStorageUtils } from 'src/app/utils/localstorage';

export abstract class BaseGuard {

    private localStorageUtils = new LocalStorageUtils();

    constructor(protected router: Router){}

    private notificarAcessoNegado() {
        this.router.navigate(['/acesso-negado']);
      }

    private validaClaims(claimsDaRota: any[], claimsDoUsuario: any[]) {
        if(!claimsDoUsuario || !claimsDaRota){
            return false;
        }

        var resultado = claimsDoUsuario.filter((usuario) => {
            return claimsDaRota.find(rota => usuario.type == rota.nome &&
                                             usuario.value == rota.valor);
        });

        if(resultado.length != claimsDaRota.length){
            this.notificarAcessoNegado();
        }
    }

    private validaClaim(claimDaRota: any, claimsDoUsuario: any){

        let claims = claimsDoUsuario.find(usuario => usuario.type === claimDaRota.nome &&
                                                     usuario.value == claimDaRota.valor);

        if(!claims){
            this.notificarAcessoNegado();
        }
    }

    protected validarClaims(activatedRoute: ActivatedRouteSnapshot) : boolean {

        if(!this.localStorageUtils.obterTokenUsuario()){
            this.router.navigate(['/usuarios/login/'], { queryParams: { returnUrl: this.router.url }});
        }

        let user = this.localStorageUtils.obterUsuario();

        let claimsDaRota: any = activatedRoute.data[0];
        if (claimsDaRota !== undefined) {

            let claims = activatedRoute.data[0]['claim'];

            if (claims) {

                if (!user.claims) {
                    this.notificarAcessoNegado();
                }

                if(Array.isArray(claims)){
                    this.validaClaims(claims, user.claims);
                } else if(typeof claims === 'object'){
                    this.validaClaim(claims, user.claims);
                }
            }
        }

        return true;
    }

    protected validarSeUsuarioEstaLogado(){
        return this.localStorageUtils.obterTokenUsuario();
    }
}
