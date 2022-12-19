using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WPFPlayRTSPExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public ObservableCollection<RtspModel> RtspModelCollection
        {
            get { return (ObservableCollection<RtspModel>)GetValue(RtspModelCollectionProperty); }
            set { SetValue(RtspModelCollectionProperty, value); }
        }

        public static readonly DependencyProperty RtspModelCollectionProperty =
            DependencyProperty.Register("RtspModelCollection", typeof(ObservableCollection<RtspModel>), typeof(MainWindow), new PropertyMetadata(null));
        public MainWindow()
        {
            InitializeComponent();
            Loaded += delegate
            {
                RtspModelCollection = new ObservableCollection<RtspModel>();
                RtspModelCollection.Add(new RtspModel { RTSPUri = "rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mp4" });
                RtspModelCollection.Add(new RtspModel { RTSPUri = "http://devimages.apple.com/iphone/samples/bipbop/gear1/prog_index.m3u8" });
                RtspModelCollection.Add(new RtspModel { RTSPUri = "http://ws.flv.huya.com/src/1394575534-1394575534-5989656310331736064-2789274524-10057-A-0-1.flv?wsSecret=cf05e7dbacda9cf2ec112517a276458c&wsTime=639bf822&fm=RFdxOEJjSjNoNkRKdDZUWV8kMF8kMV8kMl8kMw%3D%3D&ctype=huya_live&txyp=o%3An6%3B&fs=bgct&sphdcdn=al_7-tx_3-js_3-ws_7-bd_2-hw_2&sphdDC=huya&sphd=264_*-265_*&exsphd=264_500,264_2000,&ratio=500" });
                RtspModelCollection.Add(new RtspModel { RTSPUri = "rtsp://admin:Ancn1111@192.168.21.128:554/h264/ch1/main/av_stream" });
                rBtn1.IsChecked = true;
            };
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(sender is RadioButton radio)
            {
                var model = radio.DataContext as RtspModel;
                if (model == null) return;
                mediaUriElement.Source = new Uri(model.RTSPUri);
            }
        }
    }
    public class RtspModel
    {
        public string RTSPUri { get; set; }
    }
}
