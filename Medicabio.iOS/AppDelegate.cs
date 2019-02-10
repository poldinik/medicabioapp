using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Social;
using UIKit;

namespace Medicabio.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            var tint = UIColor.FromRGB(10, 149, 145);

            tint = UIColor.FromRGB(15, 173, 194);
            //UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(250, 250, 250); //bar background
            //UINavigationBar.Appearance.TintColor = tint; //Tint color of button items

            //UIBarButtonItem.Appearance.TintColor = tint; //Tint color of button items

            UITabBar.Appearance.TintColor = tint;

            UITextAttributes txtAttributes = new UITextAttributes
            {
                Font = UIFont.FromName("Montserrat-Regular", 9.0F)
            };
            UITabBarItem.Appearance.SetTitleTextAttributes(txtAttributes, UIControlState.Normal);


            UISwitch.Appearance.OnTintColor = tint;

            UIAlertView.Appearance.TintColor = tint;

            //serve per elimare l'ombra nella barra header per creare continuità con il content sottostante
            UINavigationBar.Appearance.ShadowImage = new UIImage();
            //UINavigationBar.Appearance.SetTitleTextAttributes(txtAttributes);

            UIView.AppearanceWhenContainedIn(typeof(UIAlertController)).TintColor = tint;
            UIView.AppearanceWhenContainedIn(typeof(UIActivityViewController)).TintColor = tint;
            UIView.AppearanceWhenContainedIn(typeof(SLComposeViewController)).TintColor = tint;
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}
