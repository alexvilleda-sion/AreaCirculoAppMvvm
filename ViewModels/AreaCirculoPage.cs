using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AreaCirculoAppMvvm_.ViewModels
{
    public class AreaCirculoViewModel : INotifyPropertyChanged
    {
        public const double PI = 3.1415926535897931;

        private string _radio;
        public string Radio
        {
            get => _radio;
            set
            {
                _radio = value;
                OnPropertyChanged();
            }
        }

        private string _resultado;
        public string Resultado
        {
            get => _resultado;
            set
            {
                _resultado = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalcularCommand { get; }
        public ICommand LimpiarCommand { get; }

        public AreaCirculoViewModel()
        {
            CalcularCommand = new Command(CalcularArea);
            LimpiarCommand = new Command(LimpiarCampos);
        }

        private void CalcularArea()
        {
            if (double.TryParse(Radio, out double radio))
            {
                double area = PI * Math.Pow(radio, 2);
                Resultado = $"Área: {area:F2}";
            }
            else
            {
                Resultado = "Ingrese un valor válido.";
            }
        }

        private void LimpiarCampos()
        {
            Radio = string.Empty;
            Resultado = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}