using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DividirConta
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultadoPage : ContentPage
	{
		public ResultadoPage (int totalPessoas, double valorTotal, int porcentagemGarcom)
		{
			InitializeComponent ();

            CalcularValorPorPessoa(totalPessoas, valorTotal, porcentagemGarcom);
        }

        private void CalcularValorPorPessoa(int totalPessoas, double valorTotal, int porcentagemGarcom)
        {
            var valorGarcom = porcentagemGarcom > 0 ? (valorTotal * porcentagemGarcom / 100) : 0;
            var valor = (valorTotal + valorGarcom) / totalPessoas;
            ValorPorPessoa.Text = $"Valor por pessoa: R$ {valor.ToString("C")}";
        }
	}
}