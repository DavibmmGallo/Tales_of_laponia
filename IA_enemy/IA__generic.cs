using System;
using System.Collections.Generic;
using System.Text;
using Tales_of_laponian_front.Characters;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
/// <summary>
/// 
/// BASE PARA CRIAR A IA DOS INIMIGOS 
/// CASO SEJA UM JOGO Q N TENHA TURNOS
/// 
/// 
/// </summary>
namespace Tales_of_laponian_front.IA_enemy
{
    public class IA__generic : Cbase,p_methods
    {
        public bool player_detected { get; set; }
        public bool is_player_reachable { get; set; } // hitbox 

        public string filepath { get; set; }
        public IA__generic(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money, string fp)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money)
        {
            filepath = fp;
        }
        public void Image_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Image img = sender as Image;
                if (img != null)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    img.Width = bitmapImage.DecodePixelWidth = 280;
                    bitmapImage.UriSource = new Uri(filepath);
                    img.Source = bitmapImage;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
