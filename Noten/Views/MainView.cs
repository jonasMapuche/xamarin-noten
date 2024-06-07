using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Widget;
using Noten.ViewsModels;

namespace Noten.Views
{
    public class MainView
    {
        Context contextBoton;

        public MainView(Context context)
        {
            Botton1(context);
            Botton2(context);
            Botton3(context);
            Botton4(context);
            Botton5(context);
            Botton6(context);
        }

        void Botton1(Context context)
        {
            MainViewModel mainViewModel = new MainViewModel();
            List<string> frase = mainViewModel.GetChord("Am");
            Button button_title = (Button) ((Activity) context).FindViewById(Resource.Id.btn_main_1);
            button_title.Text = frase[0];
        }
        
        void Botton2(Context context)
        {
            MainViewModel mainViewModel = new MainViewModel();
            List<string> frase = mainViewModel.GetChord("C");
            Button button_title = (Button) ((Activity) context).FindViewById(Resource.Id.btn_main_2);
            button_title.Text = frase[0];
        }

        void Botton3(Context context)
        {
            MainViewModel mainViewModel = new MainViewModel();
            List<string> frase = mainViewModel.GetChord("G");
            Button button_title = (Button) ((Activity) context).FindViewById(Resource.Id.btn_main_3);
            button_title.Text = frase[0];
        }

        void Botton4(Context context)
        {
            MainViewModel mainViewModel = new MainViewModel();
            List<string> frase = mainViewModel.GetChord("A");
            Button button_title = (Button) ((Activity) context).FindViewById(Resource.Id.btn_main_4);
            button_title.Text = frase[0];
        }

        void Botton5(Context context)
        {
            MainViewModel mainViewModel = new MainViewModel();
            List<string> frase = mainViewModel.GetChord("E");
            Button button_title = (Button) ((Activity) context).FindViewById(Resource.Id.btn_main_5);
            button_title.Text = frase[0];
        }

        void Botton6(Context context)
        {
            MainViewModel mainViewModel = new MainViewModel();
            List<string> frase = mainViewModel.GetChord("D");
            Button button_title = (Button) ((Activity) context).FindViewById(Resource.Id.btn_main_6);
            button_title.Text = frase[0];
        }
    }
}