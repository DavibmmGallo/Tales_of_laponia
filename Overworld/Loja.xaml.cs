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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Tales_of_laponian_front.Overworld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Loja : Page
    {
        public Loja()
        {
            this.InitializeComponent();
        }
        temp_battle tmp = null;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            tmp = e.Parameter as temp_battle;
            GoldShow.Text = tmp.jogador.Money.ToString();
        }
        private void OnHover1(object sender, PointerRoutedEventArgs e)
        {
            var but = sender as Button;

            but.Content = "Essa poção da ao usuario 100 de xp";

        }

        private void Clear(object sender, PointerRoutedEventArgs e)
        {
            var but = sender as Button;

            but.Content = "";
        }

        private void OnHover2(object sender, PointerRoutedEventArgs e)
        {
            var but = sender as Button;

            but.Content = "Essa poção Recupera 20% da \nsua Vida durante o combate";
        }

        private void OnHover3(object sender, PointerRoutedEventArgs e)
        {
            var but = sender as Button;

            but.Content = "Essa poção Recupera 20% da \nsua Mana durante o combate";
        }

        private void XPbuy(object sender, RoutedEventArgs e)
        {

        }

        private void HPbuy(object sender, RoutedEventArgs e)
        {

        }

        private void MPbuy(object sender, RoutedEventArgs e)
        {

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            navto(tmp.map);
        }

        /// <summary>
        /// navega com parametros para de volta a pagina
        /// </summary>
        /// <param name="m"></param>
        public void navto(string m)
        {
            if (m == "map1")
            {
                Frame.Navigate(typeof(map1), tmp.jogador);
            }
            if (m == "map2")
            {
                Frame.Navigate(typeof(map2), tmp.jogador);
            }
            if (m == "trainingmap")
            {
                Frame.Navigate(typeof(trainingmap), tmp.jogador);
            }
            if (m == "map4")
            {
                Frame.Navigate(typeof(map4), tmp.jogador);
            }
            if (m == "bossmap")
            {
                Frame.Navigate(typeof(bossmap), tmp.jogador);
            }
            return;
        }
    }
}
