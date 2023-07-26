import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import { VeiculoService } from '../services/veiculo.service';
import { Veiculo } from '../models/veiculo';

@Component({
  selector: 'app-excluir',
  templateUrl: './excluir.component.html',
  styleUrls: []
})
export class ExcluirComponent implements OnInit {

  veiculo: Veiculo;

  constructor(private service: VeiculoService,
              private route: ActivatedRoute,
              private router: Router,
              private toastr: ToastrService){}

  ngOnInit(): void {
    this.veiculo = this.route.snapshot.data['veiculo'];
  }

  private processarRequisicaoComSucesso() {
    const toast = this.toastr.success('Veíeventoculo excluido com Sucesso!', 'Registro excluído com sucesso');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/veiculos/listar']);
      });
    }
  }

  private processarRequisicaoComFalha() {
    this.toastr.error('Houve um erro no processamento!', 'Erro ao excluir o veículo');
  }

  public excluir() {
    this.service.excluir(this.veiculo)
    .subscribe({
      next: (v) => {
        this.processarRequisicaoComSucesso();
      },
      error: (e) => {
        this.processarRequisicaoComFalha();
      },
      complete: () => console.info('complete')
    });
  }
}
