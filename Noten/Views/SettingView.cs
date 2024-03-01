using Android.App;
using Android.Content;
using Android.Widget;
using Noten.ViewsModels;

namespace Noten.Views
{
    public class SettingView
    {
        public SettingView(Context context)
        {
            SettingViewModel settingViewModel = new SettingViewModel();

            TextView text_abou = (TextView)((Activity) context).FindViewById(Resource.Id.tex_viw_about);
            text_abou.Text = settingViewModel.getAbout();
        }
    }
}