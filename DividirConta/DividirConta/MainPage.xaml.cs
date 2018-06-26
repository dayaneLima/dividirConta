using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DividirConta
{
	public partial class MainPage : ContentPage
	{
        public int TotalPessoas { get; set; }
        public double ValorTotal { get; set; }
        public int PorcentagemGarcom { get; set; }

        public MainPage()
		{
			InitializeComponent();

            LimparButton.Clicked += LimparButton_Clicked;
            CalcularButton.Clicked += CalcularButton_Clicked;
        }

        private void CalcularButton_Clicked(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Navigation.PushAsync(new ResultadoPage(TotalPessoas, ValorTotal, PorcentagemGarcom));
            }
        }        

        private void LimparButton_Clicked(object sender, EventArgs e)
        {
            TotalPessoasEntry.Text = string.Empty;
            ValorTotalEntry.Text = string.Empty;
            PorcentagemGarcomEntry.Text = string.Empty;
        }

        private bool IsValid()
        {
            var valido = true;
            var mensagemErro = string.Empty;

            if (int.TryParse(TotalPessoasEntry.Text, out int totalPessoas) && totalPessoas > 0)
            {
                TotalPessoas = totalPessoas;
            }
            else
            {
                valido = false;
                mensagemErro += "Total de pessoas inválido\n";
            }

            if (double.TryParse(ValorTotalEntry.Text, out double valorTotal) && valorTotal > 0)
            {
                ValorTotal = valorTotal;
            }
            else
            {
                valido = false;
                mensagemErro += "Valor total inválido\n";
            }

            if (!string.IsNullOrEmpty(PorcentagemGarcomEntry.Text))
            {
                if (int.TryParse(PorcentagemGarcomEntry.Text, out int porcentagemGarcom))
                {
                    PorcentagemGarcom = porcentagemGarcom;
                }
                else
                {
                    valido = false;
                    mensagemErro += "Porcentagem do garçom inválido\n";
                }
            }

            if (!valido)
            {
                DisplayAlert("Ops",mensagemErro,"Ok");
            }

            return valido;
        }
    }
}
