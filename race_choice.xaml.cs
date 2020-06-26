using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Tales_of_laponian_front.Characters;
using Tales_of_laponian_front.Characters.Race;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Tales_of_laponian_front
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class race_choice : Page
    {
        public Raca raca;
        public race_choice()
        {
            this.InitializeComponent();
            ApplicationView view = ApplicationView.GetForCurrentView();
            view.TryEnterFullScreenMode();
        }

        private void show_description(object sender, PointerRoutedEventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Name)
            {
                case "Human_btn":
                    Description_box.Text = "Humano\n Passiva de raça : ganha 25% a mais de dinheiro.";
                    break;
                case "Elf_btn":
                    Description_box.Text = "Elfo\n Passiva de raça : Acertos críticos ocorrem a cada 3 hits.";
                    break;
                case "Orc_btn":
                    Description_box.Text = "Orc\n Passiva de raça : Ganha +25 dano por uso de melee.";
                    break;
                case "Tiel_btn":
                    Description_box.Text = "Tiel \n Passiva de raça : Mais vida.";
                    break;
                case "Drac_btn":
                    Description_box.Text = "Dragon \n Passiva de raça : Dano por round.";
                    break;
                case "interr_btn":
                    Description_box.Text = "????????????????????????????????????????????????????????????????????????????";
                    break;
            }
        }

        private void Clear_box_d(object sender, PointerRoutedEventArgs e)
        {
            Description_box.Text = "";
        }

        private void Confirm_ch(object sender, RoutedEventArgs e)
        {
            var ch_btn = sender as Button;
            switch (ch_btn.Name)
            {
                case "Human_btn":
                    Humano h = new Humano();
                    raca = h;
                    break;
                case "Elf_btn":
                    Elfo el = new Elfo();
                    raca = el;
                    break;
                case "Orc_btn":
                    Orc o = new Orc();
                    raca = o;
                    break;
                case "Tiel_btn":
                    Tielfing t = new Tielfing();
                    raca =t;
                    break;
                case "Drac_btn":
                    Draconic d = new Draconic();
                    raca = d;
                    break;
                case "interr_btn":
                    shark srk = new shark();
                    raca = srk;
                    break;
            }
            Frame.Navigate(typeof(Class_choice),raca);
        }
    }
}
