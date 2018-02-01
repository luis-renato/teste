using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using CarouselView.FormsPlugin.Android;
using Com.OneSignal;
using PerpetualEngine.Storage;
using Xamarin.Forms;

namespace MoNeg.Droid
{
    [Activity(Label = "Bradesco Monitoração", Icon = "@drawable/icone_app", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            SimpleStorage.EditGroup = (string groupName) =>
            {
                return new DroidSimpleStorage(groupName, this);
            };

            global::Xamarin.Forms.Forms.Init(this, bundle);

            CarouselViewRenderer.Init();

            LoadApplication(new App());

            OneSignal.Current.StartInit("d3a754b2-b601-4f1f-b016-493474fa99cb").EndInit();

            Context context = this.ApplicationContext;
			Settings.Default.Build = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionCode.ToString();
            Settings.Default.Version = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}