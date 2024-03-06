using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Widget;
using Noten.ViewsModels;

namespace Noten.Views
{
    public class MainView
    {
        public MainView(Context context)
        {
            Botton1(context);
            Botton2(context);
            Botton3(context);
        }

        void Botton1(Context context)
        {
            MainViewModel mainViewModel = new MainViewModel();
            List<string> frase = mainViewModel.GetChord("AM");
            Button button_title = (Button) ((Activity) context).FindViewById(Resource.Id.btn_main_1);
            button_title.Text = frase[0];
        }
        
        void Botton2(Context context)
        {
            MainViewModel mainViewModel = new MainViewModel();
            List<string> frase = mainViewModel.GetChord("CM");
            Button button_title = (Button) ((Activity) context).FindViewById(Resource.Id.btn_main_2);
            button_title.Text = frase[0];
        }

        void Botton3(Context context)
        {
            MainViewModel mainViewModel = new MainViewModel();
            List<string> frase = mainViewModel.GetChord("GM");
            Button button_title = (Button) ((Activity) context).FindViewById(Resource.Id.btn_main_3);
            button_title.Text = frase[0];
        }
    }
}