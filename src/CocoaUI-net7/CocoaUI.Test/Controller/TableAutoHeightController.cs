using System;
using CocoaUiBinding;
using Foundation;
namespace CocoaUI.Test
{
	public class TableAutoHeightController :ITable
	{
		public TableAutoHeightController()
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
			this.RegisterViewClass(new ObjCRuntime.Class("ListItemView3"), "item");
			AddDataRow(NSObject.FromObject("a"), "item");
			AddDataRow(NSObject.FromObject("a\nb\nc\n"), "item");
			AddDataRow(NSObject.FromObject("Xamarin,\nhello world"), "item");
			AddDataRow(NSObject.FromObject("您好，世界\n我去。"), "item");
			Reload();
		}
	}
	///jst like UITableCell
	[Register("ListItemView3")]
	public class ListItemView3 : IView
	{
		ILabel _label;
		public ListItemView3() : base()
		{
			_label = new ILabel();
			_label.Style.Set("text-align: center; width: 100%; margin: 8 0;");
			AddSubview(_label);
			this.Style.Set("border-bottom: 1 solid #ccc;");
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
				_label.Text = value.ToString();
			}
		}
	}

}

