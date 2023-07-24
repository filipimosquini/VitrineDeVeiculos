export class LocalStorageUtils {

    public obterUsuario() {
        return JSON.parse(localStorage.getItem('vitrinedeveiculos.user'));
    }

    public salvarDadosLocaisUsuario(response: any) {
        this.salvarTokenUsuario(response.accessToken);
        this.salvarUsuario(response.userToken);
    }

    public limparDadosLocaisUsuario() {
        localStorage.removeItem('vitrinedeveiculos.token');
        localStorage.removeItem('vitrinedeveiculos.user');
    }

    public obterTokenUsuario(): string {
        return localStorage.getItem('vitrinedeveiculos.token');
    }

    public salvarTokenUsuario(token: string) {
        localStorage.setItem('vitrinedeveiculos.token', token);
    }

    public salvarUsuario(user: string) {
        localStorage.setItem('vitrinedeveiculos.user', JSON.stringify(user));
    }
}
