using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;
using System.Threading.Tasks;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {
                        string dados_previsao = "";

                        dados_previsao = $"Descrição: {t.description} \n" +
                                         $"Latitude: {t.lat} \n" +
                                         $"Longitude: {t.lon} \n" +
                                         $"velicidade do Vendto: {t.speed} \n" +
                                         $"Visibilidade: {t.visibility} \n" +
                                         $"Nascer do Sol: {t.sunrise} \n" +
                                         $"Por do Sol: {t.sunset} \n" +
                                         $"Temp Min: {t.temp_min} \n" +
                                         $"Temp Max: {t.temp_max} \n";
                        lbl_res.Text = dados_previsao;
                    }
                    else
                    {
                        lbl_res.Text = "Sem dados de Previsão.";
                    }

                }
                else
                {
                    lbl_res.Text = "Prencha a cidade.";
                }
            }catch (Exception ex) 
            {
            await DisplayAlert("Ops", ex.Message, "OK");
            }

        }
    }
}
