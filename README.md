# Dividir Conta
Projeto Demo para o curso de férias de Introdução ao Xamarin Forms da PUC Minas Contagem - 2018.

Dividir conta é um App nativo feito em Xamarin Forms para calcular o valor que cada pessoa pagará na hora de dividir a conta do restaurante.

## Como criar um projeto Xamarin Forms no Visual Studio
![Criar Projeto Xamarin Forms](https://github.com/dayaneLima/dividirConta/blob/master/Docs/Imgs/dividirContaCriacaoProjeto.gif)

## Navegação - App.xaml.cs
Como usaremos navegação entre telas, temos que definir que nossa tela inicial seja chamada já utilizando navegação. Abra o arquivo App.xaml.cs, no construtor tem o seguinte código:

```c#
  MainPage = new MainPage();
```

Altere para o cógido abaixo:

```c#
  MainPage = new NavigationPage(new MainPage());
```

## Primeira tela

Na tela principal temos os campos para preencher o número de pessoas, valor total e a porcentagem do garçom. Também há um botão para limpar os dados preenchidos e outro para calcular o valor total que cada pessoa pagará. Ao clicar em calcular, um nova tela se abrirá exibindo o resultado do cálculo.

Abaixo se encontra o código do Layout da tela:

  ```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:DividirConta"
             x:Class="DividirConta.MainPage"
             Title="Dividir Conta"
             Padding="10">
    <StackLayout>
        <Label Text="Total de pessoas:" />
        <Entry Keyboard="Numeric"
               x:Name="TotalPessoasEntry"/>
        <Label Text="Valor total:" />
        <Entry Keyboard="Numeric"
               x:Name="ValorTotalEntry"/>
        <Label Text="Porcentagem garçom:" />
        <Entry Keyboard="Numeric"
               x:Name="PorcentagemGarcomEntry"/>      
        
        <Grid>            
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*" />
                <ColumnDefinition Width="*" />
            </Grid.ColumnDefinitions>            
            <Grid.RowDefinitions>
                <RowDefinition Height="*" />
            </Grid.RowDefinitions>
            <Button Text="Limpar"
                    Grid.Column="0"
                    Grid.Row="0" 
                    x:Name="LimparButton"/>            
            <Button Text="Calcular"
                    Grid.Column="1"
                    Grid.Row="0"
                    x:Name="CalcularButton"/>            
        </Grid>             
    </StackLayout>
</ContentPage>

  ```
  
  Agora vamos criar o Code Behind que será responsável por validar os dados da tela e pelas ações dos botões de limpar e calcular:
  
  Primeiro vamos adicionar as propriedades para a classe representando nossos elementos da tela:
  
  ```c#
      public int TotalPessoas { get; set; }
      public double ValorTotal { get; set; }
      public int PorcentagemGarcom { get; set; }
  ```

Após, vamos criar as chamadas das funções de click no botão de limpar e calcular:

  ```c#
   public MainPage()
   {
	 InitializeComponent();
            
         LimparButton.Clicked += LimparButton_Clicked;
         CalcularButton.Clicked += CalcularButton_Clicked;
    }
    
    private void LimparButton_Clicked(object sender, EventArgs e)
    {
	 	throw new NotImplementedException();
    }
    
    private void CalcularButton_Clicked(object sender, EventArgs e)
    {
		throw new NotImplementedException();
    }
  ```
  
  Na função de limpar, vamos apagar todos os textos dos elementos da tela:

 ```c#
     private void LimparButton_Clicked(object sender, EventArgs e)
        {
            TotalPessoasEntry.Text = string.Empty;
            ValorTotalEntry.Text = string.Empty;
            PorcentagemGarcomEntry.Text = string.Empty;
        }
 ```
 
 Quando clicarmos em calcular, devemos validar se os dados preenchidos estão corretos, para isso vamos criar a função IsValid():
 
 
  ```c#
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
  ```
  
  Agora vamos implementar a função  de calcular, ela chamará a função de validação de dados e se estiver tudo correto, chamará a próxima tela que exibirá o resultado:  
  
  ```c#
    private void CalcularButton_Clicked(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Navigation.PushAsync(new ResultadoPage(TotalPessoas, ValorTotal, PorcentagemGarcom));
            }
        }  
  ```
  
## Como criar uma page no Visual Studio

![Criar Page](https://github.com/dayaneLima/dividirConta/blob/master/Docs/Imgs/dividirContaCriarPage.gif)

## Link para baixar o FontAwesome (Baixar versão web)

<a href="https://fontawesome.com"  target="_blank"> FontAwesome</a>

## Adicionar Font Awesome no projeto

![Adicionar Font Awesome](https://github.com/dayaneLima/dividirConta/blob/master/Docs/Imgs/dividirContaAddFontAwesome.gif)

## Segunda tela

Na segunda tela é feito o cálculo do valor pago por pessoa e exibido na tela. Abaixo se encontra o XAML:

 ```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="DividirConta.ResultadoPage"
             Title="Resultado">
    <ContentPage.Content>
        <StackLayout HorizontalOptions="CenterAndExpand"
                        VerticalOptions="CenterAndExpand">            
            <StackLayout Orientation="Horizontal">
                <Label Text="&#xf1ec;" FontSize="Large">
                    <Label.FontFamily>
                        <OnPlatform x:TypeArguments="x:String" 
                                    Android="fa-solid-900.ttf#Font Awesome 5 Free Solid" 
                                    iOS="Font Awesome 5 Free"/>
                    </Label.FontFamily>
                </Label>
                <Label FontSize="Large"
                       x:Name="ValorPorPessoa"/>                
            </StackLayout>            
        </StackLayout>
    </ContentPage.Content>
</ContentPage>

  ```
  
  Agora o Code Behind responsável pelo cálculo e atribuir o valor total ao elemento da tela:
  
  ```c# 
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
            ValorPorPessoa.Text = $"Valor por pessoa: {valor.ToString("C")}";
        }
	}
}
```

## Visualização com o Xamarin Live Reload

Para visualizar o layout a medida que as telas estão sendo criadas pode-se utilizar o Xamarin Live Reload. Seu Visual Studio deve está  no mínimo na versão 15.7 e o projeto do Xamarin Forms deve estar ser no mínimo na versão 3.0.

Para instalar o Live Reload primeiro é necessário instalar o plugin no Visual Studio. Vá em Tools -> Extensions and Update -> Online e pesquise Xamarin Live Reload - Preview. Ao encontrar clique em Download, após feche seu Visual Studio que ele começará a instalação. Abaixo é mostrado uma demo de como é esse processo:

![Install Live Reload Visual Studio](https://github.com/dayaneLima/dividirConta/blob/master/Docs/Imgs/dividirContaInstallLiveReload.gif)

Após a instalação, abra seu projeto Xamarin Forms no Visual Studio, clique sobre sua solution com o botão direito e vá em Manage Nuget Packages for Solution, na guia de Browse pesquise por Xamarin.LiveReload e marque o Package Resource para All, se não você não conseguirá achar a biblioteca. Após clique em instalar e marque seu Projeto principal, o Android e IOS.

Em seguida, vá no seu projejto principal, abra o App.xaml.cs, no construtor dessa classe, antes do método InitializeComponent(), adicione o trecho de código abaixo:

```c#
#if DEBUG
LiveReload.Init();
#endif
```

Agora execute seu projeto no emulador, assim que o mesmo estiver abrindo, vai aparecer uma tarja amarela com um aviso e informando que você deve clicar em connect e então clicar nesta opção para ativar o live reload.

Pronto, agora toda alteração que fizer no layout, assim que clicar em salvar, será exibida no seu emulador.

Abaixo segue um gif ilustrando esse processo completo:

![Add Live Reload Xamarin Forms](https://github.com/dayaneLima/dividirConta/blob/master/Docs/Imgs/dividirContaXamarinLiveReload.gif)

## Demo

![Criar Page](https://github.com/dayaneLima/dividirConta/blob/master/Docs/Imgs/dividirContaDemoApp.gif)

## Slides 

<a href="https://github.com/dayaneLima/dividirConta/blob/master/Docs/xamarinIntroducao.pdf"  target="_blank"> Slide da Apresentação</a>

