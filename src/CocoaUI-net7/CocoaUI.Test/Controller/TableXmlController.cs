using System;
using CocoaUiBinding;
using Foundation;
namespace CocoaUI.Test
{
	public class TableXmlController:ITable
	{
		public TableXmlController()
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
			this.RegisterViewClass(new ObjCRuntime.Class("ListItemView2"), "item");
			AddDataRow(NSObject.FromObject("off"), "item");
			AddDataRow(NSObject.FromObject("off"), "item");
			AddDataRow(NSObject.FromObject("on"), "item");
			AddDataRow(NSObject.FromObject("off"), "item");
			AddDataRow(NSObject.FromObject("on"), "item");
			AddDataRow(NSObject.FromObject("off"), "item");
			Reload();
		}
	}
	///jst like UITableCell
	[Register("ListItemView2")]
	public class ListItemView2 : IView
	{
		
		public ListItemView2() : base()
		{
			var subView = IView.NamedView("buy");
			AddSubview(subView);
			this.Style.Set("height: 300; border-bottom: 1 solid #ccc;");
		}
		public override Foundation.NSObject Data
		{
			get
			{
				return base.Data;
			}
			set
			{
				base.Data = value;
				var price = (Subviews[0] as IView).GetViewById("price") as ILabel;
				price.Text = value.Equals(NSObject.FromObject("on")) ? "12.00" : "11.00";
				Style.Set(value.Equals(NSObject.FromObject("on"))?"background: #ff3":"background: #eee");
			}
		}
	}

}

