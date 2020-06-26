using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Tales_of_laponian_front.IA_enemy;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Tales_of_laponian_front.Overworld
{
    /// <summary>
    /// Mapa 03 - Entrada da Dungeon de NULLPOINTERs
    /// </summary>
    public sealed partial class trainingmap : Page
    {
        public trainingmap()
        { 
            this.InitializeComponent();
            ///entra em fullscreen 
            ApplicationView view = ApplicationView.GetForCurrentView();
            view.TryEnterFullScreenMode();
            Fuk.Focus(FocusState.Programmatic);
        }
        public Characters.Cbase player;// player da outra fase
        private enemy_randomizer enemy_Randomizer = new enemy_randomizer();
        private bool lockout_battle = false;
        int kpo = 0;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            player = e.Parameter as Characters.Cbase;
            player.task_xp();
            ON_MOV_CURR(player.position);
        }

        public int[,] colisionbox = new int[,] { {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                 {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 3, 3, 3, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                                 {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }};
        // 0  = parede
        // 1 = pode ir
        // 2 =player´pos
        private int[] pos = new int[2] { 33 , 16 };
        public bool is_paused = false;
        protected override async void OnKeyUp(KeyRoutedEventArgs e)
        {
            base.OnKeyUp(e);
            if (!is_paused)
            {
                show_st_player();
                if(e.Key == Windows.System.VirtualKey.Down)
                {
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, Down_ev);
                }
                else if (e.Key == Windows.System.VirtualKey.Up)
                {
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, Up_ev);
                }
                else if (e.Key == Windows.System.VirtualKey.Left)
                {
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, Left_ev);
                }
                else if (e.Key == Windows.System.VirtualKey.Right)
                {
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, Right_ev);
                }
                else if (e.Key == Windows.System.VirtualKey.F3)
                {
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, show_game_stats);
                }
            }
            if (e.Key == Windows.System.VirtualKey.Escape)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, Pause_state);
            }
            if (kpo != 0) kpo--;
            player.Pos_attp(pos);
        }
        /// <summary>
        /// translatam o mapa 32px para cada lado , fazendo a ilusão de "movimento"
        /// </summary>
        public async void Down_ev()
        {
            if (colisionbox[pos[0] + 1, pos[1]] == 1)
            {
                int x = 0;
                while (x < 2)
                {
                    ImgBFTranslateTransform.Y -= 16;
                    await Task.Delay(50);
                    x++;
                }
                pos[0] += 1;
                if (!lockout_battle) can_battle();
            }
            else if (colisionbox[pos[0] + 1, pos[1]] == 3)
            {
                int x = 0;
                while (x < 2)
                {
                    ImgBFTranslateTransform.Y -= 16;
                    await Task.Delay(50);
                    x++;
                }
                //black screen
                player.position = new int[2] { 11, 27};
                Frame.Navigate(typeof(map2), player);
            }
            attp_pos();
            Console.Write("down");
        }
        /// <summary>
        /// goes up by threading
        /// </summary>
        public async void Up_ev()
        {
            if (colisionbox[pos[0] - 1, pos[1]] == 1)
            {
                int x = 0;
                while (x < 2)
                {
                    ImgBFTranslateTransform.Y += 16;
                    await Task.Delay(50);
                    x++;
                }
                pos[0] -= 1;
                if (!lockout_battle) can_battle();
            }
            else if (colisionbox[pos[0] - 1, pos[1]] == 3)
            {
                int x = 0;
                while (x < 2)
                {
                    ImgBFTranslateTransform.Y += 16;
                    await Task.Delay(50);
                    x++;
                }
                //black screen
                player.position = null;
                Frame.Navigate(typeof(map4),player);
            }
            attp_pos();
            Console.Write("up");
        }
        /// <summary>
        /// goes left
        /// </summary>
        public async void Left_ev()
        {
            if (colisionbox[pos[0], pos[1] - 1] == 1)
            {
                int x = 0;
                while (x < 2)
                {
                    ImgBFTranslateTransform.X += 16;
                    await Task.Delay(50);
                    x++;
                }
                pos[1] -= 1;
                if (!lockout_battle) can_battle();
            }
            
            attp_pos();
            Console.Write("left");
        }
        /// <summary>
        /// goes right
        /// </summary>
        public async void Right_ev()
        {
            if (colisionbox[pos[0], pos[1] + 1] == 1)
            {
                int x = 0;
                while (x < 2)
                {
                    ImgBFTranslateTransform.X -= 16;
                    await Task.Delay(50);
                    x++;
                }
                pos[1] += 1;
                if (!lockout_battle) can_battle();
            }
            
            attp_pos();
            Console.Write("right");
        }
        void show_st_player()
        {
            hp_id.Text = player.HP.ToString();
            mp_id.Text = player.MP.ToString();
            str_id.Text = player.Strength.ToString();
            int_id.Text = player.Intelligence.ToString();
            tou_id.Text = player.Toughness.ToString();
            lvl_id.Text = "LVL : " + ((int)player.Lvl).ToString();
            money_id.Text = player.Money.ToString();
            xp_id.Text = "XP : " + ((int)player.XP).ToString() + " / " + ((int)player.MAXXP).ToString();
        }
        /// <summary>
        /// debug console 4k HD 
        /// </summary>
        public void show_game_stats()
        {
            if (stats_box.Visibility == Visibility.Visible)
            {
                stats_box.Visibility = Visibility.Collapsed;
                stats_boxen.Visibility = Visibility.Collapsed;
                commandbar.Visibility = Visibility.Collapsed;
            }
            else
            {
                commandbar.Visibility = Visibility.Visible;
                stats_box.Visibility = Visibility.Visible;
                stats_boxen.Visibility = Visibility.Visible;
            }
        }
        /// <summary>
        /// pausar jogo
        /// </summary>
        public void Pause_state()
        {
            //save?
            is_paused = !is_paused;
            if (is_paused) Pause_xaml.Visibility = Visibility.Visible;
            else Pause_xaml.Visibility = Visibility.Collapsed;
            //show pause//

        }
        /// <summary>
        /// Função que identifica a batalha
        /// [Achar inimigo] [quais inimigos] [sort()]
        /// </summary>
        void can_battle()
        {
            if (enemy_Randomizer.Found() && kpo == 0 && !player.repel)
            {
                var parameters = new temp_battle(null, null, null);
                switch (enemy_Randomizer.randon(3))
                {
                    case 1:
                        IA__generic ia = null;
                        ia = enemy_Randomizer.set_enemies(ia, 3);
                        Slime slime = Slime.Convert_to_Slime(ia);
                        stats_boxen.Text = "1 :\n LVL : " + ia.Lvl + "\n money : " + ia.Money + "\n HP : " + ia.HP;
                        parameters = new temp_battle(player, slime, "trainingmap");
                        Frame.Navigate(typeof(Battlescreen), parameters);
                        break;
                    case 2:
                        IA__generic iab = null;
                        iab = enemy_Randomizer.set_enemies(iab, 3);
                        Goblin goblin = Goblin.Convert_to_goblin(iab);
                        stats_boxen.Text = "2 :\n LVL : " + iab.Lvl + "\n money : " + iab.Money + "\n HP : " + iab.HP;
                        parameters = new temp_battle(player, iab, "trainingmap");
                        Frame.Navigate(typeof(Battlescreen), parameters);
                        break;
                    case 3:
                        IA__generic iac = null;
                        iac = enemy_Randomizer.set_enemies(iac, 3);
                        Morfrok morfrok = Morfrok.Convert_to_morfrok(iac);
                        stats_boxen.Text = "3 :\n LVL : " + iac.Lvl + "\n money : " + iac.Money + "\n HP : " + iac.HP;
                        parameters = new temp_battle(player, morfrok, "trainingmap");
                        Frame.Navigate(typeof(Battlescreen), parameters);
                        break;
                    default:
                        break;
                }
                //Battle scene
                show_st_player();
            }
        }
        /// <summary>
        /// atualiza posiçao de acordo com as tasks de movimento
        /// </summary>
        void attp_pos()
        {
            try
            {
                stats_box.Text = "X : " + pos[1] + " Y : " + pos[0] + "\n" + colisionbox[pos[0] - 1, pos[1] - 1] + " " +
                                                                                    colisionbox[pos[0] - 1, pos[1]] + " " +
                                                                                    +colisionbox[pos[0] - 1, pos[1] + 1] + "\n"
                                                                                    + colisionbox[pos[0], pos[1] - 1] + "    "
                                                                                    + colisionbox[pos[0], pos[1] + 1] + "\n"
                                                                                    + colisionbox[pos[0] + 1, pos[1] - 1] + " "
                                                                                    + colisionbox[pos[0] + 1, pos[1]] + " "
                                                                                    + colisionbox[pos[0] + 1, pos[1] + 1];
                show_st_player();
            }
            catch (Exception e)
            {
                MessageDialog msgerror = new MessageDialog("[I01] - " + e.Message);
            }
        }
        /// <summary>
        /// UWP nao presta p pegar focus 
        /// </summary>
        /// <param name="sender"> obj q enviou o signal de evento</param>
        /// <param name="e"> evento </param>
        private void fuck(object sender, RoutedEventArgs e)
        {
            Fuk.Content = "Muito bem vc encontrou a porra de um botao de 1x1px \n";
        }
        /// <summary>
        /// botao de resume game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Resume(object sender, RoutedEventArgs e)
        {
            Pause_xaml.Visibility = Visibility.Collapsed;
            is_paused = false;
        }
        /// <summary>
        /// save stats from player in progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_p_data(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(@"\\saves", "teste");
        }
        /// <summary>
        /// exit game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_game(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }
        public void ON_MOV_CURR(int[] posit)
        {
            if (posit != null)
            {
                lockout_battle = true;
                int Y = posit[0] - pos[0];
                int X = posit[1] - pos[1];

                while (X > 0)
                {
                    Right_ev();
                    X -= 1;
                }
                while (X < 0)
                {
                    Left_ev();
                    X += 1;
                }
                while (Y > 0)
                {
                    Down_ev();
                    Y -= 1;
                }
                while (Y < 0)
                {
                    Up_ev();
                    Y += 1;
                }
            }
            kpo = 2;
            lockout_battle = false;
        }
        string cmd_str = "";
        public void command_list()
        {
            cmd_str = commandbar.Text;
            if (cmd_str == "repel true") player.repel = true;
            else if (cmd_str == "repel false") player.repel = false;
            else if (cmd_str == "chr davizudo")
            {
                BitmapImage bitmapImage = new BitmapImage();
                Player.Width = bitmapImage.DecodePixelWidth = 73;
                Player.Stretch = Stretch.Fill;
                bitmapImage.UriSource = new Uri("ms-appx:///Assets/default_personagem.gif");
                Player.Source = bitmapImage;
            }
            else if (cmd_str == "chr helltaker")
            {
                BitmapImage bitmapImage = new BitmapImage();
                Player.Width = bitmapImage.DecodePixelWidth = 32;
                Player.Stretch = Stretch.UniformToFill;
                bitmapImage.UriSource = new Uri("ms-appx:///Assets/player_idle.gif");
                Player.Source = bitmapImage;
            }
        }
        private async void ck_commandAsync(object sender, KeyRoutedEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                cmd_str = commandbar.Text;
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, command_list);
                
            }
        }
    }
}
