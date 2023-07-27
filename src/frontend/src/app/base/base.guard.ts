import { Router, ActivatedRouteSnapshot } from '@angular/router';
import { LocalStorageUtils } from 'src/app/utils/localstorage';

export abstract class BaseGuard {

    public localStorageUtils = new LocalStorageUtils();

    constructor(protected router: Router){}

    protected validarClaims(routeAc: ActivatedRouteSnapshot) : boolean {

        if(!this.localStorageUtils.obterTokenUsuario()){
            this.router.navigate(['/usuarios/login/'], { queryParams: { returnUrl: this.router.url }});
        }

        let user = this.localStorageUtils.obterUsuario();

        let claim: any = routeAc.data[0];
        if (claim !== undefined) {
            let claim = routeAc.data[0]['claim'];

            if (claim) {
                if (!user.claims) {
                    this.notificarAcessoNegado();
                }

                let userClaims = user.claims.find(x => x.type === claim.nome);

                if(!userClaims){
                    this.notificarAcessoNegado();
                }

                let valoresClaim = userClaims.value as string;

                if (!valoresClaim.includes(claim.valor)) {
                    this.notificarAcessoNegado();
                }
            }
        }

        return true;
    }

    private notificarAcessoNegado() {
      this.router.navigate(['/acesso-negado']);
    }
}
