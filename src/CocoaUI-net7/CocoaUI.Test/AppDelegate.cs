namespace CocoaUI.Test;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {
	public override UIWindow? Window {
		get;
		set;
	}

	public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
		// create a new window instance based on the screen size
		Window = new UIWindow (UIScreen.MainScreen.Bounds);

        // create a UIViewController with a single UILabel
        var nav = new UINavigationController();
        Window.RootViewController = nav;

        nav.PushViewController(new HomeController(), true);

        // make the window visible
        Window.MakeKeyAndVisible ();

		return true;
	}
}

