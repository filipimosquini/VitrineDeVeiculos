import { Marca } from "./marca";
import { Modelo } from "./modelo";

export interface Veiculo{
  id: string;
  nome: string;
  valor: number;
  marcaId: string;
  modeloId: string;
  uploadDaImagem: string;
  nomeDaImagem: string,

  marca: Marca;
  modelo: Modelo;
}
