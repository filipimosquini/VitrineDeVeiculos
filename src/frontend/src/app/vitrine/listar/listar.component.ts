import { Component, OnInit } from '@angular/core';
import { Veiculo } from 'src/app/veiculos/models/veiculo';
import { VeiculoService } from 'src/app/veiculos/services/veiculo.service';

@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrls: []
})
export class ListarComponent implements OnInit{

  public veiculos: Veiculo[];

  constructor(private veiculoService: VeiculoService) { }

  ngOnInit(): void {
    this.veiculoService.listar()
    .subscribe({
      next: (v) => {this.veiculos = v},
      error: (e) => {},
      complete: () => {}
    });
  }
}
