using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Tales_of_laponian_front.Characters;
using Tales_of_laponian_front.Characters.Classes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
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
    public sealed partial class Battlescreen : Page
    {
        public Battlescreen()
        {
            this.InitializeComponent();
            ApplicationView view = ApplicationView.GetForCurrentView();
            view.TryEnterFullScreenMode();
        }

        public Cbase player;// player da outra fase
        public IA_enemy.IA__generic enemy;
        temp_battle parametros;
        public int turno = 0;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            parametros = e.Parameter as temp_battle;
            player = parametros.jogador;
            enemy = parametros.inimigo;
            setbattle();
        }
        
       /// <summary>
       /// Seta as info da batalha
       /// </summary>
        public void setbattle()
        {
            Enemy_Name_Copy.Text = player.ToString().Replace("Tales_of_laponian_front.Characters.Classes.","");
            Enemy_Name.Text = enemy.ToString().Replace("Tales_of_laponian_front.IA_enemy.", "");
            Enemy_lvl_Display.Text = "LVL : "+enemy.Lvl.ToString();
            Enemy_lvl_Display_Copy.Text =  "LVL : " + ((int)player.Lvl).ToString();
            EnemyHp.Value = enemy.HP;
            inv_list.ItemsSource = player.inventory.inventory;
            ATK1.Content = player.get_atk_name(1);
            ATK2.Content = player.get_atk_name(2);
            ATK3.Content = player.get_atk_name(3);
            ATK4.Content = player.get_atk_name(4);
            enemy_hp_num.Text = enemy.HP + " / " + enemy.MAXHP;
            player_hp_num.Text = player.HP + " / " + player.MAXHP;
            attp_HPbar(EnemyHp_Copy);
            attp_HPbar(EnemyHp);
            attp_MPbar(player_mana_bar);
            player.raca.Image_Loaded(player_img, new RoutedEventArgs());
            enemy.Image_Loaded(inimigo_img, new RoutedEventArgs());
        }
        void enemy_attk()
        {
            if (enemy.GetType() == typeof(IA_enemy.IA__generic))
            {
                player.take_dmg(100);
            }
            else
            {
                Random random = new Random();
                int at = random.Next(1, 2);

                if (at == 1)
                    enemy.atkk1(player, new EventArgs());
                else
                    enemy.atkk2(player, new EventArgs());
            }
        }
        /// <summary>
        /// O uso dos butoes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ataque(object sender, RoutedEventArgs e)
        {
            player.MAXCP += 10;
            player.CP += 10;

            turno++;
            
            var btn = sender as Button;
            player.current_enemy = enemy;
            player.turn = turno;
            enemy.current_enemy = player;
            
            switch (btn.Name)
            {
                case "ATK1":
                    player.atkk1(enemy,new EventArgs());
                    break;
                case "ATK2":
                    player.atkk2(enemy, new EventArgs());
                    break;
                case "ATK3":
                    player.atkk3(enemy, new EventArgs());
                    break;
                case "ATK4":
                    player.atkk4(enemy, new EventArgs());
                    break;
                case "Basic_Hit":
                    player.atkbasic(enemy,(int)player.inventory.Main_weapon.dmg);
                    break;
                case "Run":
                    MessageDialog msgerror = new MessageDialog("");
                    msgerror.Content = "Que covardia! Money lost : "+ 10;
                    player.Money -= 10;
                    navto(parametros.map);
                    msgerror.ShowAsync();
                    break;
                default:
                    break;
            }

            attp_HPbar(EnemyHp);
            attp_MPbar(player_mana_bar);

            if (enemy.isDead)
            {
                player.Money += enemy.Money;
                player.XP += enemy.Lvl+100;
                MessageDialog msgerror = new MessageDialog("");
                msgerror.Content = "Vc ganhou, money earned += " + enemy.Money.ToString();
                navto(parametros.map);
                player.gain_HP(99999);
                player.gain_MP(99999);
                msgerror.ShowAsync();
            }
            else
                enemy_attk();

            attp_HPbar(EnemyHp_Copy);
            player.untouchable = false;
            enemy.untouchable = false;

            if (player.isDead)
            {
                player.lose_money(enemy.Money);
                MessageDialog msgerror = new MessageDialog("");
                msgerror.Content = "Vc perdeu, money lose -= " + enemy.Money.ToString();
                player.gain_HP(99999);
                player.gain_MP(99999);
                navto(parametros.map);
                msgerror.ShowAsync();
            }            
        } 

        /// <summary>
        /// navega com parametros para de volta a pagina
        /// </summary>
        /// <param name="m"></param>
        public void navto(string m)
        {
            player.CP = 0;
            if(m == "map1")
            {
                Frame.Navigate(typeof(map1), player);
            }
            if (m == "map2")
            {
                Frame.Navigate(typeof(map2), player);
            }
            if (m == "trainingmap")
            {
                Frame.Navigate(typeof(trainingmap), player);
            }
            if (m == "map4")
            {
                Frame.Navigate(typeof(map4), player);
            }
            if (m == "bossmap")
            {
                Frame.Navigate(typeof(bossmap), player);
            }
            return;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            bag_scene.Visibility = Visibility.Collapsed;
        }
        private void Bagin(object sender, RoutedEventArgs e)
        {
            bag_scene.Visibility = Visibility.Visible;
        }

        private void attp_HPbar(object sender)
        {
            var progress_bar = sender as ProgressBar;
            if(progress_bar.Name == "EnemyHp_Copy")
            {
                progress_bar.Value = 100 * (player.HP / player.MAXHP);
                if (progress_bar.Value <= 50 && progress_bar.Value >= 25) progress_bar.Foreground = new SolidColorBrush(Colors.Yellow);
                else if (progress_bar.Value <= 25) progress_bar.Foreground = new SolidColorBrush(Colors.Red);
            }
            else if (progress_bar.Name == "EnemyHp")
            {
                progress_bar.Value = 100 * (enemy.HP / enemy.MAXHP);
                if (progress_bar.Value <= 50 && progress_bar.Value >= 25) progress_bar.Foreground = new SolidColorBrush(Colors.Yellow);
                else if (progress_bar.Value <= 25) progress_bar.Foreground = new SolidColorBrush(Colors.Red);
            }
            enemy_hp_num.Text = enemy.HP + " / " + enemy.MAXHP;
            player_hp_num.Text = player.HP + " / " + player.MAXHP;
        }
        private void attp_MPbar(object sender)
        {
            var progress_bar = sender as ProgressBar;
            if(player.MAXMP != 0)
            {
                if (progress_bar.Name == "player_mana_bar")
                {
                    progress_bar.Value = 100 * (player.MP / player.MAXMP);
                }
            }
            else
            {
                player_mana_bar.Visibility = Visibility.Collapsed;
                player_mp.Visibility = Visibility.Collapsed;
            }
           
        }
    }
   
}
