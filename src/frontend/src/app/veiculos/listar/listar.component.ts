import { Component, OnInit } from '@angular/core';
import { Veiculo } from '../models/veiculo';
import { VeiculoService } from '../services/veiculo.service';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/enviroment';

@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrls: []
})
export class ListarComponent implements OnInit {

  imagens: string = environment.imagensUrl;

  errors: any[] = [];
  public veiculos: Veiculo[];

  constructor(private service: VeiculoService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.listar()
    .subscribe({
      next: (veiculos) => { this.veiculos = veiculos },
      error: (e) => {
        this.veiculos = [];
        this.processarRequisicaoComFalha(e);
      },
      complete: () => {}
    });
  }

  private processarRequisicaoComFalha(fail: any){
    this.errors = fail.error.errors;
    this.toastr.error("Ocorreu um erro", "Erro ao realizar esta operação.")
  }
}
