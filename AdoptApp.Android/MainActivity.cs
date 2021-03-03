using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Database;
using Android.Provider;
using Android.Graphics;
using System.IO;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace AdoptApp.Droid
{
    [Activity(Label = "AdoptApp", Icon = "@drawable/logo", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
		internal static MainActivity Instance { get; private set; }

		protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

			Instance = this;
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

		public static readonly int PickImageId = 1000;

		public TaskCompletionSource<Stream> PickImageTaskCompletionSource { set; get; }

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);

			//Since we set the request code to 1 for both the camera and photo gallery, that's what we need to check for
			if (requestCode == PickImageId)
			{
				if ((resultCode == Result.Ok) && (data.Data != null))
				{
					Android.Net.Uri uri = data.Data;
					Stream stream = ContentResolver.OpenInputStream(uri);

					// Set the Stream as the completion of the Task
					PickImageTaskCompletionSource.SetResult(stream);
				}
				else
				{
					PickImageTaskCompletionSource.SetResult(null);
				}
			}
		}
	}
}