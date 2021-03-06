﻿using MinhaCasa.Domain.NaoContemplados.Interfaces;

namespace MinhaCasa.Domain.NaoContemplados.Commands
{
    public class ResultadoCommand : IResultadoCommand
    {
        public int Pontuacao { get; set; }
        public int QuantidadeCriteriosAtendidos { get; set; }
        public bool Sucesso { get; set; }
        public object MensagemErro { get; set; }

        public ResultadoCommand() { }

        public ResultadoCommand(int pontuacao, int quantidadeCriteriosAtendidos, bool sucesso, object mensagemErro = null)
        {
            Pontuacao = pontuacao;
            QuantidadeCriteriosAtendidos = quantidadeCriteriosAtendidos;
            Sucesso = sucesso;
            MensagemErro = mensagemErro;
        }
    }
}