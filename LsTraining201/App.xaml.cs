using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace LsTraining201
{
    public partial class App : Application
    {
        // メンバ
        private Label lbl01 = new Label { Text = "Hello, Xamarin!" };
        private Button btn01 = new Button { Text = "ChangeButton" };
        private Entry ety01 = new Entry { Text = "" };
        private Button btn02 = new Button { Text = "CopyButton" };
        private Button btn03 = new Button { Text = "AddBtn" };
        private Button btn04 = new Button { Text = "ClearBtn" };
        private Entry ety02 = new Entry { Text = "" };
        private StackLayout sLayout = new StackLayout { };
        private ListView list01 = new ListView { RowHeight = 40 };
        private ObservableCollection<string> strlist = new ObservableCollection<string>();

        public App ()
        {
            double top;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    top = 50;
                    break;
                case Device.Android:
                case Device.UWP:
                default:
                    top = 0;
                    break;
            }
            Thickness thic = new Thickness(10, top, 10, 10);

            // 入れ子のStackLayoutの初期化
            sLayout.Children.Add(btn03);
            sLayout.Children.Add(btn04);
            sLayout.Orientation = StackOrientation.Horizontal;

            list01.ItemsSource = strlist;

            // ページの定義
            MainPage = new ContentPage
            {
            Content = new StackLayout
                {
                    Margin = thic,
                    Children =
                    {
                        new Label { Text = "Hello, Forms!", },
                        lbl01,
                        btn01,
                        ety01,
                        btn02,
                        new Label { Text = "◆ListView"},
                        ety02,
                        sLayout,
                        list01,
                    }
                },

            };
            // ボタンのクリックイベントを設定
            btn02.Clicked += delegate
            {
                if (!string.IsNullOrEmpty(ety01.Text))
                {
                    lbl01.Text = ety01.Text;
                    ety01.Text = string.Empty;
                }
            };
            btn03.Clicked += delegate
            {
                if (!string.IsNullOrEmpty(ety02.Text))
                {
                    strlist.Add(ety02.Text);
                    ety02.Text = string.Empty;
                }
            };
            btn04.Clicked += delegate
            {
                strlist.Clear();
            };
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
