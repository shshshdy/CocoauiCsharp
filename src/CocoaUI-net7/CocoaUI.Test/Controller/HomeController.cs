using CocoaUiBinding;
using UIKit;

namespace CocoaUI.Test
{

	public class HomeController : ITable
	{

		public HomeController()
		{
		}
		public override void ViewWillAppear(bool animated)
		{
			NavigationController.NavigationBarHidden = false;
			base.ViewWillAppear(animated);
		}

		public override void ViewDidLoad()
		{

			base.ViewDidLoad();
			NavigationItem.Title = "home";
			NavigationController.NavigationBar.Translucent = false;
			View.BackgroundColor = UIColor.GroupTableViewBackground;

			AddButton("login");
			AddButton("buy");
			AddButton("threeCloumn");
			AddButton("table");
			AddButton("tableXml");
			AddButton("tableAutoHeight");


		}
		void AddButton(string text)
		{
			var btn = new IButton() { Text = text };
			var style = "";
			if (text.Equals("table"))
			{
				style = "margin-top:10;margin-bottom: 0; width: 100%; height: 40; background: #fff; border-bottom: 1px solid #ddd;";
			}
			else if (text.StartsWith("table"))
			{

				style = "margin-bottom: 0; width: 100%; height: 40; background: #fff; border-bottom: 1px solid #ddd;";
			}
			else
			{
				style = "margin-bottom: 0; margin-top:10; width: 100%; height: 40; background: #fff; border-bottom: 1px solid #ddd;";
			}
			btn.Style.Set(style);
			AddIViewRow(btn);
			btn.AddEvent(IEventType.Click | IEventType.Highlight | IEventType.Unhighlight, (e, v) =>
			{
				if (e == IEventType.Highlight)
				{
					v.Style.Set("background: #ffe;");
				}
				else if (e == IEventType.Unhighlight)
				{
					v.Style.Set("background: #fff;");
				}
				else
				{
					var ib = v as IButton;
					ClickBtn(ib.Button);
				}
			});
		}
		void ClickBtn(UIButton btn)
		{
			var text = btn.TitleLabel.Text;
			UIViewController controller;
			if (text.Equals("login"))
			{
				controller = new LoginController();
			}
			else if (text.Equals("buy"))
			{
				controller = new BuyController();
			}
			else if (text.Equals("threeCloumn"))
			{
				controller = new ThreeCloumController();
			}
			else if (text.Equals("table"))
			{
				controller = new TableController();
			}
			else if (text.Equals("tableXml"))
			{
				controller = new TableXmlController();
			}
			else
			{
				controller = new TableAutoHeightController();
			}

			NavigationController.PushViewController(controller, true);
		}



	}
}