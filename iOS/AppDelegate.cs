using System.Net;
using System.Threading;
using CarouselView.FormsPlugin.iOS;
using Com.OneSignal;
using Foundation;
using KeyboardOverlap.Forms.Plugin.iOSUnified;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using Syncfusion.SfChart.XForms.iOS.Renderers;
using Syncfusion.SfDataGrid.XForms.iOS;
using Syncfusion.SfNavigationDrawer.XForms.iOS;
using Syncfusion.SfPullToRefresh.XForms.iOS;
using UIKit;

namespace MoNeg.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			ServicePointManager.ServerCertificateValidationCallback +=
	            (sender, cert, chain, sslPolicyErrors) => true;

			global::Xamarin.Forms.Forms.Init();

            CarouselViewRenderer.Init();

            KeyboardOverlapRenderer.Init();
            SfDataGridRenderer.Init();
            SfListViewRenderer.Init();
            SfPullToRefreshRenderer.Init();
            new SfChartRenderer();
            new SfBusyIndicatorRenderer();

            LoadApplication(new App());
            new SfNavigationDrawerRenderer();

			OneSignal.Current.StartInit("d3a754b2-b601-4f1f-b016-493474fa99cb").EndInit();

            Settings.Default.Build = NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleVersion")].ToString();
            Settings.Default.Version = NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleShortVersionString")].ToString();

            return base.FinishedLaunching(app, options);
        }
    }
}