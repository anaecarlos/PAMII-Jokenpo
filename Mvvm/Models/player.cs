using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jokenpô.Mvvm.Models
{
        public enum Opcao
        {
            Pedra,
            Papel,
            Tesoura
        }

        public class JogoModel
        {
            public Opcao EscolhaUsuario { get; set; }
            public Opcao EscolhaComputador { get; set; }

            public void Jogar()
            {
                var random = new Random();
                EscolhaComputador = (Opcao)random.Next(0, 3);
            }

            public string ObterResultado()
            {
                if (EscolhaUsuario == EscolhaComputador)
                    return "Empate";
                if ((EscolhaUsuario == Opcao.Pedra && EscolhaComputador == Opcao.Tesoura) ||
                    (EscolhaUsuario == Opcao.Papel && EscolhaComputador == Opcao.Pedra) ||
                    (EscolhaUsuario == Opcao.Tesoura && EscolhaComputador == Opcao.Papel))
                    return "Você ganhou!";

                return "Você perdeu!";
            }
        }
    }
