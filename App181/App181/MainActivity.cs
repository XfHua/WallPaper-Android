using System;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace App181
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            setWallpaper();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void setWallpaper() {

            Bitmap bitmap = BitmapFactory.DecodeResource(Resources,Resource.Drawable.sample);

            WallpaperManager manager = WallpaperManager.GetInstance(ApplicationContext);

            manager.SetBitmap(bitmap);
            //or
            manager.SetBitmap(bitmap, null, true, WallpaperManagerFlags.Lock);

        }

        //private void setWallpaper()
        //{
        //    Bitmap bitmap = BitmapFactory.decodeResource(getResources(), R.drawable.wallpaper);
        //    WallpaperManager manager = WallpaperManager.getInstance(getApplicationContext());
        //    try
        //    {
        //        manager.setBitmap(bitmap);
        //        Toast.makeText(this, "Wallpaper set!", Toast.LENGTH_SHORT).show();
        //    }
        //    catch (IOException e)
        //    {
        //        Toast.makeText(this, "Error!", Toast.LENGTH_SHORT).show();
        //    }
        //}
    }
}

