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
using Tales_of_laponian_front.Characters.Classes;
using Tales_of_laponian_front.Characters.Race;
using Windows.UI.ViewManagement;
using Tales_of_laponian_front.Items.weapons;
using Tales_of_laponian_front.Items.misc;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Tales_of_laponian_front
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Class_choice : Page
    {
        /// <summary>
        /// <see cref="osasko" = pegar a classe escolhida anteriormente/>
        /// <see cref="player" = parametro do player construido/>
        /// </summary>
        Raca osasko;

        public Characters.Cbase player;
        public Class_choice()
        {
            this.InitializeComponent();
            ApplicationView view = ApplicationView.GetForCurrentView();
            view.TryEnterFullScreenMode();
        }
        /// <summary>
        /// Passar para a prox xaml
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            osasko = e.Parameter as Raca; 
        }
        /// <summary>
        /// confirma a seleção
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirrm_class(object sender, RoutedEventArgs e)
        {
            var ch_btn = sender as Button;
            switch (ch_btn.Name)
            {
                case "Assassin_btn":
                    player = new Assassin(100,100,0,4,2,4,1,10);
                    player.inventory.Main_weapon = new Training_sword();
                    break;
                case "Berserk_btn":
                    player = new Berserker(200,50,0,5,7,1,1,10);
                    player.inventory.Main_weapon = new Training_sword();
                    break;
                case "Mage_btn":
                    player = new Mage(90, 0, 200, 2, 2, 9, 1, 10);
                    player.inventory.Main_weapon = new Training_staff();
                    break;
                case "Necro_btn":
                    player = new Necromancer(75, 0, 300, 2, 2, 15, 1, 10);
                    player.inventory.Main_weapon = new Training_staff();
                    break;
                case "Swords_btn":
                    player = new Swordsman(150, 100, 0, 5, 5, 5, 1, 10);
                    player.inventory.Main_weapon = new Training_sword();
                    break;
            }
            player.inventory.append_item(new HealthPotion(), 0);
            player.inventory.append_item(new HealthPotion(), 1);
            player.inventory.append_item(new ManaPotion(), 2);
            player.inventory.append_item(new ManaPotion(), 3);
            player.raca = osasko;
            Frame.Navigate(typeof(Overworld.History),player);
        }
        /// <summary>
        /// Mostra a descrição das classes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void show_description(object sender, PointerRoutedEventArgs e)
        {
            var btn = sender as Button;
            
            switch (btn.Name)
            {
                case "Assassin_btn":
                    Description_class_box.Text = "~descrição aq~ [habilidades e movimentos]";
                    break;
                case "Berserk_btn":
                    Description_class_box.Text = "~descrição aq~ [habilidades e movimentos]";
                    break;
                case "Mage_btn":
                    Description_class_box.Text = "~descrição aq~ [habilidades e movimentos]";
                    break;
                case "Necro_btn":
                    Description_class_box.Text = "~descrição aq~ [habilidades e movimentos]";
                    break;
                case "Swords_btn":
                    Description_class_box.Text = "~descrição aq~ [habilidades e movimentos]";
                    break;
            }
        }
        /// <summary>
        /// Clear na caixa de descrição
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clear_d(object sender, PointerRoutedEventArgs e)
        {
            Description_class_box.Text = "";
        }
    }
}
