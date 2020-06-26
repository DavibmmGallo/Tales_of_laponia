using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Tales_of_laponian_front.Characters.Race
{
    public class Raca
    {
        public string img_path { get; set; } //img da raca

        public double buff { get; set; } //passiva 
        public void Image_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Image img = sender as Image;
                if (img != null)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    img.Width = bitmapImage.DecodePixelWidth = 280;
                    bitmapImage.UriSource = new Uri(img_path);
                    img.Source = bitmapImage;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
