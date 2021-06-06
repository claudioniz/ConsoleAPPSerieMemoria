using DadoMemoria.Enumeradores;
using System;

namespace DadoMemoria.Models
{
    public class Serie : EntidadeBase
    {
        // Atributos
        public Genero Genero { get; private set; }
        public string Titulo { get;private set; }
        public string Descricao { get; private set; }
        public int Ano { get; private set; }

        // Métodos
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            // Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += $"Excluido: {(this.Excluido? "Sim": "Não")}";
            return retorno;
        }

        public string DadosSerie()
        {
            return $"{PrepararValorLinha(this.Id,3)}{PrepararValorLinha(this.Genero,20)}{PrepararValorLinha(this.Titulo,25)}{PrepararValorLinha(this.Descricao,30)}{PrepararValorLinha(this.Ano,5)}{PrepararValorLinha(this.Excluido? "Sim":"Não",7)}";
        }

        private string PrepararValorLinha(object valor, int tamanho)
        {
            string retorno = string.Empty;

            if (valor != null)
            {
                if (valor.ToString().Length >= tamanho)
                {
                    retorno = valor.ToString().Substring(0, tamanho-4) + "... ";
                }
                else
                {
                    retorno = valor.ToString().PadRight(tamanho, ' ');
                }
            }
            else
            {
                retorno = retorno.PadRight(tamanho, ' ');
            }

            return retorno;
        }
    }

}
