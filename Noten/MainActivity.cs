using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Google.Android.Material.Navigation;
using AndroidX.DrawerLayout.Widget;
using Letter.Resources.helpers;
using AndroidX.Core.View;
using Noten.Views;

namespace Noten
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        private const double ACTION_BACK = 16908332;

        private Navigation navigaton = Navigation.Home;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            MainView main = new MainView(this);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            if (navigaton == Navigation.Home) MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                NavigationSetting();
                return true;
            }
            if (id == ACTION_BACK)
            {
                NavigationHome();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            /*
                View view = (View) sender;
                Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            */
            NavigationBot();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_home)
            {
                NavigationHome();
            }
            else if (id == Resource.Id.nav_bot)
            {
                NavigationBot();
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }

        public void NavigationSetting()
        {
            Android.Widget.FrameLayout frame_main;
            frame_main = FindViewById<Android.Widget.FrameLayout>(Resource.Id.frm_lay_main);
            frame_main.Visibility = ViewStates.Invisible;

            Android.Widget.FrameLayout frame_setting;
            frame_setting = FindViewById<Android.Widget.FrameLayout>(Resource.Id.frm_lay_setting);
            frame_setting.Visibility = ViewStates.Visible;

            Android.Widget.FrameLayout frame_bot;
            frame_bot = FindViewById<Android.Widget.FrameLayout>(Resource.Id.frm_lay_bot);
            frame_bot.Visibility = ViewStates.Invisible;

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            toolbar.SetNavigationIcon(Resource.Drawable.ic_back);

            navigaton = Navigation.Setting;

            SettingView setting = new SettingView(this);
        }

        public void NavigationHome()
        {
            Android.Widget.FrameLayout frame_main;
            frame_main = FindViewById<Android.Widget.FrameLayout>(Resource.Id.frm_lay_main);
            frame_main.Visibility = ViewStates.Visible;

            Android.Widget.FrameLayout frame_setting;
            frame_setting = FindViewById<Android.Widget.FrameLayout>(Resource.Id.frm_lay_setting);
            frame_setting.Visibility = ViewStates.Invisible;

            Android.Widget.FrameLayout frame_bot;
            frame_bot = FindViewById<Android.Widget.FrameLayout>(Resource.Id.frm_lay_bot);
            frame_bot.Visibility = ViewStates.Invisible;

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            navigaton = Navigation.Home;
        }

        public void NavigationBot()
        {
            Android.Widget.FrameLayout frame_main;
            frame_main = FindViewById<Android.Widget.FrameLayout>(Resource.Id.frm_lay_main);
            frame_main.Visibility = ViewStates.Invisible;

            Android.Widget.FrameLayout frame_setting;
            frame_setting = FindViewById<Android.Widget.FrameLayout>(Resource.Id.frm_lay_setting);
            frame_setting.Visibility = ViewStates.Invisible;

            Android.Widget.FrameLayout frame_bot;
            frame_bot = FindViewById<Android.Widget.FrameLayout>(Resource.Id.frm_lay_bot);
            frame_bot.Visibility = ViewStates.Visible;

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            toolbar.SetNavigationIcon(Resource.Drawable.ic_back);

            navigaton = Navigation.Bot;

            BotView bot = new BotView(this);
        }

    }
}
