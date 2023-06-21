using System;
using CocoaUiBinding;
using CoreGraphics;
using UIKit;
namespace CocoaUI.Test
{
	public class ThreeCloumController :ITable
	{
		CGPoint _firstPoint;
		public ThreeCloumController()
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

			var subView = IView.NamedView("three-cols");
			AddIViewRow(subView);
			Reload();

			var pan = subView.GetViewById("pan") as IView;
			var gest = new UIPanGestureRecognizer((g) => {
				var point = g.TranslationInView(subView);
				if (g.State == UIGestureRecognizerState.Began)
				{
					_firstPoint = pan.Center;
				}
				if (g.State == UIGestureRecognizerState.Changed)
				{
					pan.Center = new CGPoint(_firstPoint.X + point.X, _firstPoint.Y + point.Y);
				}
				if (g.State == UIGestureRecognizerState.Ended)
				{
					UIView.Animate(0.3, 0, UIViewAnimationOptions.CurveEaseInOut, () => { pan.Center = _firstPoint; },null);
				}
			});
			pan.AddGestureRecognizer(gest);

		}
	}
}

