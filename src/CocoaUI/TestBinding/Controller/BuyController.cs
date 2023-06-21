using System;
using CocoaUiBinding;
using UIKit;

namespace TestBinding
{
	public class BuyController : ITable
	{
		public BuyController()
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
			var view = IView.NamedView("buy");
			AddIViewRow(view);
			this.Reload();
		}
	}
}


