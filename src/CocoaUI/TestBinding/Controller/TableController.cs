using System;
using CocoaUiBinding;
using Foundation;
namespace TestBinding
{
	public class TableController:ITable
	{
		public TableController()
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
			this.RegisterViewClass(new ObjCRuntime.Class("ListItemView"), "item");
			AddDataRow(NSObject.FromObject("off"), "item");
			AddDataRow(NSObject.FromObject("off"), "item");
			AddDataRow(NSObject.FromObject("on"), "item");
			AddDataRow(NSObject.FromObject("on"), "item");
			AddDataRow(NSObject.FromObject("off"), "item");
			AddDataRow(NSObject.FromObject("off"), "item");
			Reload();
		}
	}
	///jst like UITableCell
	[Register("ListItemView")]
	public class ListItemView : IView
	{
		
		public ListItemView() : base()
		{
			var subView = new IView();
			subView.Style.Set("float: center; valign: middle; width: 100; height: 50; background: #3cf;");
			AddSubview(subView);
			this.Style.Set("height: 100; border-bottom: 1 solid #ccc;");
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
				Style.Set(value.Equals(NSObject.FromObject("on"))?"background: #ff3":"background: #eee");
			}
		}
	}

}

