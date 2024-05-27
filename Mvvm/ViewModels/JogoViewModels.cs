using System.ComponentModel;
using System.Windows.Input;
using Jokenpô.Mvvm.Models;

namespace Jokenpô.Mvvm.ViewModels
{
    public class JogoViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private JogoModel _jogoModel;
        private string _mensagem;
        private string _escolhaImagem;
        private string _escolhaComputadorImagem;

        public ICommand JogarCommand { get; }

        public string Mensagem
        {
            get => _mensagem;
            set
            {
                if (_mensagem != value)
                {
                    _mensagem = value;
                    OnPropertyChanged(nameof(Mensagem));
                }
            }
        }

        public string EscolhaImagem
        {
            get => _escolhaImagem;
            set
            {
                if (_escolhaImagem != value)
                {
                    _escolhaImagem = value;
                    OnPropertyChanged(nameof(EscolhaImagem));
                }
            }
        }

        public string EscolhaComputadorImagem
        {
            get => _escolhaComputadorImagem;
            set
            {
                if (_escolhaComputadorImagem != value)
                {
                    _escolhaComputadorImagem = value;
                    OnPropertyChanged(nameof(EscolhaComputadorImagem));
                }
            }
        }

        public Opcao EscolhaUsuario { get; set; }

        public JogoViewModels()
        {
            _jogoModel = new JogoModel();
            JogarCommand = new Command(ExecutarJogada);
        }

        private void ExecutarJogada()
        {
            _jogoModel.EscolhaUsuario = EscolhaUsuario;
            _jogoModel.Jogar();
            DefinirImagens(_jogoModel.EscolhaUsuario, _jogoModel.EscolhaComputador);
            Mensagem = ObterMensagem(_jogoModel.EscolhaUsuario, _jogoModel.EscolhaComputador);
        }

        private void DefinirImagens(Opcao escolhaUsuario, Opcao escolhaComputador)
        {
            switch (escolhaUsuario)
            {
                case Opcao.Pedra:
                    EscolhaImagem = "pedra.png";
                    break;
                case Opcao.Papel:
                    EscolhaImagem = "papel.png";
                    break;
                case Opcao.Tesoura:
                    EscolhaImagem = "tesoura.png";
                    break;
                default:
                    EscolhaImagem = null;
                    break;
            }

            switch (escolhaComputador)
            {
                case Opcao.Pedra:
                    EscolhaComputadorImagem = "pedra.png";
                    break;
                case Opcao.Papel:
                    EscolhaComputadorImagem = "papel.png";
                    break;
                case Opcao.Tesoura:
                    EscolhaComputadorImagem = "tesoura.png";
                    break;
                default:
                    EscolhaComputadorImagem = null;
                    break;
            }
        }

        private string ObterMensagem(Opcao escolhaUsuario, Opcao escolhaComputador)
        {
            string mensagem = $"Você escolheu: {escolhaUsuario}\n";
            mensagem += $"Computador escolheu: {escolhaComputador}\n";

            if (escolhaUsuario == escolhaComputador)
                mensagem += "Empate";
            else if ((escolhaUsuario == Opcao.Pedra && escolhaComputador == Opcao.Tesoura) ||
                     (escolhaUsuario == Opcao.Papel && escolhaComputador == Opcao.Pedra) ||
                     (escolhaUsuario == Opcao.Tesoura && escolhaComputador == Opcao.Papel))
                mensagem += "Você ganhou!";
            else
                mensagem += "Você perdeu!";

            return mensagem;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
