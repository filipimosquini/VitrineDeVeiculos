import { Component, OnInit } from '@angular/core';
import { Veiculo } from 'src/app/veiculos/models/veiculo';
import { VeiculoService } from 'src/app/veiculos/services/veiculo.service';
import { FiltroVeiculo } from '../models/filtroVeiculo';
import { environment } from 'src/enviroments/enviroment';
import { Marca } from 'src/app/veiculos/models/marca';
import { Modelo } from 'src/app/veiculos/models/modelo';

@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrls: ['./listar.component.css']
})
export class ListarComponent implements OnInit{

  imagens: string = environment.imagensUrl;

  public veiculos: Veiculo[];
  public marcas: Marca[] = [];
  public modelos: Modelo[] = [];
  public filtro: FiltroVeiculo= {
    nome: '',
    valorInicio: null,
    valorFim: null,
    marcaId: '',
    modeloId: ''
  };

  constructor(protected service: VeiculoService) { }

  ngOnInit(): void {

    this.filtrar();

    this.listarMarcas();
  }

  listarMarcas(){
    this.service.listarMarcas()
    .subscribe({
      next: (marcas) => { this.marcas = marcas },
      error: (e) => {
        this.marcas = [];
      },
      complete: () => {}
    });
  }

  listarModelos(marcaId: string){
    this.service.listarModelos(marcaId)
    .subscribe({
      next: (modelos) => { this.modelos = modelos },
      error: (e) => {
        this.modelos = [];
      },
      complete: () => {}
    });
  }

  filtrar(){
    this.service.listarComFiltros(this.filtro)
    .subscribe({
      next: (v) => {
        this.veiculos = v;
      },
      error: (e) => {},
      complete: () => {}
    });
  }

  limpar(){
    this.filtro = {
      nome: '',
      valorInicio: null,
      valorFim: null,
      marcaId: '',
      modeloId: ''
    };

    this.modelos = [];

    this.listarMarcas();

    this.filtrar();
  }
}
