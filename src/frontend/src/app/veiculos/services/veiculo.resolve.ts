import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { VeiculoService } from "./veiculo.service";
import { Veiculo } from "../models/veiculo";
import { Injectable } from "@angular/core";

@Injectable()
export class VeiculoResolve implements Resolve<Veiculo> {

    constructor(private service: VeiculoService) { }

    resolve(route: ActivatedRouteSnapshot) {
        return this.service.obter(route.params['id']);
    }
}
