using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DuanZi
{
    public class ImageGifView : MediaElement
    {
        public ImageGifView()
        {
            this.SourceUpdated -= ImageGifView_SourceUpdated;
            this.SourceUpdated += ImageGifView_SourceUpdated;
            this.Loaded -= ImageGifView_Loaded;
            this.Loaded += ImageGifView_Loaded;
        }

        private void ImageGifView_Loaded(object sender, RoutedEventArgs e)
        {
            PlayVideo();
        }

        private void ImageGifView_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            PlayVideo();
        }

        private void PlayVideo()
        {
            this.LoadedBehavior = MediaState.Manual;
            this.Stretch = Stretch.Fill;
            this.Play();
            //循环播放
            this.MediaEnded -= ImageGifView_MediaEnded;
            this.MediaEnded += ImageGifView_MediaEnded;
        }
        private void ImageGifView_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaElement media = (MediaElement)sender;
            media.Position = TimeSpan.FromMilliseconds(1);
            media.Play();
        }
    }
}
