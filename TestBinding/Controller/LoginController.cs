using System;
using System.Drawing;
using CocoaUiBinding;
using CoreFoundation;
using UIKit;
using Foundation;

namespace TestBinding
{

    [Register("LoginController")]
    public class LoginController : ITable
    {
		IImage _logo;
		IInput _name;
		IInput _password;
		IView _captchaDiv;
		IButton _submit;

        public LoginController()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }
		public override void ViewWillAppear(bool animated)
		{
			NavigationController.NavigationBarHidden = true;
			base.ViewWillAppear(animated);
		}

        public override void ViewDidLoad()
        {
            
            base.ViewDidLoad();
            IView view = IView.NamedView("login");
            this.AddIViewRow(view);
            this.Reload();
			_logo = view.GetViewById("logo") as IImage;
			_submit = view.GetViewById("submit") as IButton;
			_captchaDiv = view.GetViewById("captcha_div") as IView;
			_name = view.GetViewById("name") as IInput;
			_password = view.GetViewById("password") as IInput;

			_submit.AddEvent(IEventType.Click, (t, v) => { 
				new UIAlertView("title",
				                "click event:\n\nname_"+_name.Value+";\n\npass_"+_password.Value,
				                new Myuidle(this),
				                null, 
				                new string[] { "buy","back"}).Show(); 
			});

        }
		private class Myuidle : UIAlertViewDelegate
		{
			ITable _table;
			public Myuidle(ITable table)
			{
				_table = table;
			}
			public override void Clicked(UIAlertView alertview, nint buttonIndex)
			{
				if (buttonIndex == 0)
				{
					_table.NavigationController.PushViewController(new BuyController(), true);
				}
				else if (buttonIndex == 1)
				{
					_table.NavigationController.PushViewController(new HomeController(), true);
				}

			}
		}
    }
}