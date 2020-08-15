using MinhaCasa.Domain.NaoContemplados.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCasa.Domain.NaoContemplados.Commands
{
    public class ResultadoCriterioCommand : ICommandResult
    {
        public int Pontuacao { get;  set; }
        public int QuantidadeCriteriosAtendidos { get;  set; }
        public bool Sucesso { get;  set; }
        public string MensagemErro { get; set; }
     
        public ResultadoCriterioCommand(){}

        public ResultadoCriterioCommand(int pontuacao, int quantidadeCriteriosAtendidos, bool sucesso, string mensagemErro = null)
        {
            Pontuacao = pontuacao;
            QuantidadeCriteriosAtendidos = quantidadeCriteriosAtendidos;
            Sucesso = sucesso;
            MensagemErro = mensagemErro;
        }
    }
}
