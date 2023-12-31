﻿namespace Backend.Domain.Veiculos.ApplicationServices.Responses;

public class VeiculoResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public string NomeDaImagem { get; set; }
    public MarcaResponse Marca { get; set; }
    public ModeloResponse Modelo { get; set; }
}