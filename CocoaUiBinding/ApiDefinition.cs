using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace CocoaUiBinding
{
	// @interface IStyle : NSObject
	[BaseType(typeof(NSObject))]
	interface IStyle
	{
		// @property (nonatomic) CGFloat width;
		[Export("width")]
		nfloat Width { get; set; }

		// @property (nonatomic) CGFloat height;
		[Export("height")]
		nfloat Height { get; set; }

		// @property (readonly, nonatomic) CGSize size;
		[Export("size")]
		CGSize Size { get; }

		// @property (readonly, nonatomic) CGFloat innerWidth;
		[Export("innerWidth")]
		nfloat InnerWidth { get; }

		// @property (readonly, nonatomic) CGFloat innerHeight;
		[Export("innerHeight")]
		nfloat InnerHeight { get; }

		// @property (readonly, nonatomic) CGFloat outerWidth;
		[Export("outerWidth")]
		nfloat OuterWidth { get; }

		// @property (readonly, nonatomic) CGFloat outerHeight;
		[Export("outerHeight")]
		nfloat OuterHeight { get; }

		// -(void)set:(NSString *)css;
		[Export("set:")]
		void Set(string css);

		// -(void)setClass:(NSString *)clz;
		[Export("setClass:")]
		void SetClass(string clz);

		// -(void)addClass:(NSString *)clz;
		[Export("addClass:")]
		void AddClass(string clz);

		// -(void)removeClass:(NSString *)clz;
		[Export("removeClass:")]
		void RemoveClass(string clz);

		// -(BOOL)hasClass:(NSString *)clz;
		[Export("hasClass:")]
		bool HasClass(string clz);
	}

	// @interface IView : UIView
	[BaseType(typeof(UIView))]
	interface IView
	{
		// @property (readonly, nonatomic) IStyle * style;
		[Export("style")]
		IStyle Style { get; }

		// +(IView *)viewWithUIView:(UIView *)view;
		[Static]
		[Export("viewWithUIView:")]
		IView ViewWithUIView(UIView view);

		// +(IView *)viewWithUIView:(UIView *)view style:(NSString *)css;
		[Static]
		[Export("viewWithUIView:style:")]
		IView ViewWithUIView(UIView view, string css);

		// +(IView *)namedView:(NSString *)name;
		[Static]
		[Export("namedView:")]
		IView NamedView(string name);

		// +(IView *)viewFromXml:(NSString *)xml;
		[Static]
		[Export("viewFromXml:")]
		IView ViewFromXml(string xml);

		// +(IView *)viewWithContentsOfFile:(NSString *)path;
		[Static]
		[Export("viewWithContentsOfFile:")]
		IView ViewWithContentsOfFile(string path);

		// -(ITable *)table;
		[Export("table")]
		//[Verify(MethodToProperty)]
		ITable Table { get; }

		// -(id)data;
		// -(void)setData:(id)data;
		[Export("data")]
		//[Verify(MethodToProperty)]
		NSObject Data { get; set; }

		// -(IView *)getViewById:(NSString *)vid;
		[Export("getViewById:")]
		IView GetViewById(string vid);

		// -(void)addSubview:(UIView *)view style:(NSString *)css;
		[Export("addSubview:style:")]
		void AddSubview(UIView view, string css);

		// -(UIViewController *)viewController;
		[Export("viewController")]
		UIViewController ViewController();

		// -(void)show;
		[Export("show")]
		void Show();

		// -(void)hide;
		[Export("hide")]
		void Hide();

		// -(void)toggle;
		[Export("toggle")]
		void Toggle();

		// -(void)bindEvent:(IEventType)event handler:(void (^)(IEventType, IView *))handler;
		[Export("bindEvent:handler:")]
		void BindEvent(IEventType @event, Action<IEventType, IView> handler);

		// -(void)addEvent:(IEventType)event handler:(void (^)(IEventType, IView *))handler;
		[Export("addEvent:handler:")]
		void AddEvent(IEventType @event, Action<IEventType, IView> handler);

		// -(BOOL)fireEvent:(IEventType)event;
		[Export("fireEvent:")]
		bool FireEvent(IEventType @event);
	}

	// @interface IButton : IView
	[BaseType(typeof(IView))]
	interface IButton
	{
		// @property (readonly, nonatomic) UIButton * button;
		[Export("button")]
		UIButton Button { get; }

		// @property (nonatomic) NSString * text;
		[Export("text")]
		string Text { get; set; }

		// +(IButton *)buttonWithText:(NSString *)text;
		[Static]
		[Export("buttonWithText:")]
		IButton ButtonWithText(string text);
	}

	// @interface IImage : IView
	[BaseType(typeof(IView))]
	interface IImage
	{
		// @property (nonatomic) UIImageView * imageView;
		[Export("imageView", ArgumentSemantic.Assign)]
		UIImageView ImageView { get; set; }

		// @property (nonatomic) NSString * src;
		[Export("src")]
		string Src { get; set; }

		// @property (nonatomic) UIImage * image;
		[Export("image", ArgumentSemantic.Assign)]
		UIImage Image { get; set; }

		// +(IImage *)imageNamed:(NSString *)name;
		[Static]
		[Export("imageNamed:")]
		IImage ImageNamed(string name);
	}

	// @interface IInput : IView
	[BaseType(typeof(IView))]
	interface IInput
	{
		// +(IInput *)textInput;
		[Static]
		[Export("textInput")]
		//[Verify(MethodToProperty)]
		IInput TextInput { get; }

		// +(IInput *)passwordInput;
		[Static]
		[Export("passwordInput")]
		//[Verify(MethodToProperty)]
		IInput PasswordInput { get; }

		// @property (readonly, nonatomic) UITextField * textField;
		[Export("textField")]
		UITextField TextField { get; }

		// @property (nonatomic) NSString * value;
		[Export("value")]
		string Value { get; set; }

		// @property (nonatomic) NSString * placeholder;
		[Export("placeholder")]
		string Placeholder { get; set; }

		// -(BOOL)isPasswordInput;
		// -(void)setIsPasswordInput:(BOOL)yesno;
		[Export("isPasswordInput")]
		//[Verify(MethodToProperty)]
		bool IsPasswordInput { get; set; }
	}

	// @interface IKitUtil : NSObject
	[BaseType(typeof(NSObject))]
	interface IKitUtil
	{
		// +(UIColor *)colorFromHex:(NSString *)hex;
		[Static]
		[Export("colorFromHex:")]
		UIColor ColorFromHex(string hex);

		// +(BOOL)isHTML:(NSString *)str;
		[Static]
		[Export("isHTML:")]
		bool IsHTML(string str);

		// +(BOOL)isHttpUrl:(NSString *)src;
		[Static]
		[Export("isHttpUrl:")]
		bool IsHttpUrl(string src);

		// +(NSString *)getRootPath:(NSString *)url;
		[Static]
		[Export("getRootPath:")]
		string GetRootPath(string url);

		// +(NSString *)getBasePath:(NSString *)url;
		[Static]
		[Export("getBasePath:")]
		string GetBasePath(string url);

		// +(NSString *)buildPath:(NSString *)basePath src:(NSString *)src;
		[Static]
		[Export("buildPath:src:")]
		string BuildPath(string basePath, string src);

		// +(BOOL)isDataURI:(NSString *)src;
		[Static]
		[Export("isDataURI:")]
		bool IsDataURI(string src);

		// +(UIImage *)loadImageFromDataURI:(NSString *)src;
		[Static]
		[Export("loadImageFromDataURI:")]
		UIImage LoadImageFromDataURI(string src);
	}

	// @interface ITable : UIViewController
	[BaseType(typeof(UIViewController))]
	interface ITable
	{
		// @property (readonly, nonatomic) IPullRefresh * pullRefresh;
		[Export("pullRefresh")]
		IPullRefresh PullRefresh { get; }

		// @property (nonatomic) IRefreshControl * headerRefreshControl;
		[Export("headerRefreshControl", ArgumentSemantic.Assign)]
		IRefreshControl HeaderRefreshControl { get; set; }

		// @property (nonatomic) IRefreshControl * footerRefreshControl;
		[Export("footerRefreshControl", ArgumentSemantic.Assign)]
		IRefreshControl FooterRefreshControl { get; set; }

		// @property (nonatomic) IView * headerView;
		[Export("headerView", ArgumentSemantic.Assign)]
		IView HeaderView { get; set; }

		// @property (nonatomic) IView * footerView;
		[Export("footerView", ArgumentSemantic.Assign)]
		IView FooterView { get; set; }

		// -(void)clear;
		[Export("clear")]
		void Clear();

		// -(void)reload;
		[Export("reload")]
		void Reload();

		// -(NSUInteger)count;
		[Export("count")]
		//[Verify(MethodToProperty)]
		nuint Count { get; }

		// -(void)removeRowAtIndex:(NSUInteger)index;
		[Export("removeRowAtIndex:")]
		void RemoveRowAtIndex(nuint index);

		// -(void)registerViewClass:(Class)ivClass forTag:(NSString *)tag;
		[Export("registerViewClass:forTag:")]
		void RegisterViewClass(Class ivClass, string tag);

		// -(void)addIViewRow:(IView *)view;
		[Export("addIViewRow:")]
		void AddIViewRow(IView view);

		// -(void)addIViewRow:(IView *)view defaultHeight:(CGFloat)height;
		[Export("addIViewRow:defaultHeight:")]
		void AddIViewRow(IView view, nfloat height);

		// -(void)addDataRow:(id)data forTag:(NSString *)tag;
		[Export("addDataRow:forTag:")]
		void AddDataRow(NSObject data, string tag);

		// -(void)addDataRow:(id)data forTag:(NSString *)tag defaultHeight:(CGFloat)height;
		[Export("addDataRow:forTag:defaultHeight:")]
		void AddDataRow(NSObject data, string tag, nfloat height);

		// -(void)prependIViewRow:(IView *)view;
		[Export("prependIViewRow:")]
		void PrependIViewRow(IView view);

		// -(void)prependIViewRow:(IView *)view defaultHeight:(CGFloat)height;
		[Export("prependIViewRow:defaultHeight:")]
		void PrependIViewRow(IView view, nfloat height);

		// -(void)prependDataRow:(id)data forTag:(NSString *)tag;
		[Export("prependDataRow:forTag:")]
		void PrependDataRow(NSObject data, string tag);

		// -(void)prependDataRow:(id)data forTag:(NSString *)tag defaultHeight:(CGFloat)height;
		[Export("prependDataRow:forTag:defaultHeight:")]
		void PrependDataRow(NSObject data, string tag, nfloat height);

		// -(void)updateIViewRow:(IView *)view atIndex:(NSUInteger)index;
		[Export("updateIViewRow:atIndex:")]
		void UpdateIViewRow(IView view, nuint index);

		// -(void)updateDataRow:(id)data forTag:(NSString *)tag atIndex:(NSUInteger)index;
		[Export("updateDataRow:forTag:atIndex:")]
		void UpdateDataRow(NSObject data, string tag, nuint index);

		// -(void)insertIViewRow:(IView *)view atIndex:(NSUInteger)index;
		[Export("insertIViewRow:atIndex:")]
		void InsertIViewRow(IView view, nuint index);

		// -(void)insertIViewRow:(IView *)view atIndex:(NSUInteger)index defaultHeight:(CGFloat)height;
		[Export("insertIViewRow:atIndex:defaultHeight:")]
		void InsertIViewRow(IView view, nuint index, nfloat height);

		// -(void)insertDataRow:(id)data forTag:(NSString *)tag atIndex:(NSUInteger)index;
		[Export("insertDataRow:forTag:atIndex:")]
		void InsertDataRow(NSObject data, string tag, nuint index);

		// -(void)insertDataRow:(id)data forTag:(NSString *)tag atIndex:(NSUInteger)index defaultHeight:(CGFloat)height;
		[Export("insertDataRow:forTag:atIndex:defaultHeight:")]
		void InsertDataRow(NSObject data, string tag, nuint index, nfloat height);

		// -(void)addDivider:(NSString *)css;
		[Export("addDivider:")]
		void AddDivider(string css);

		// -(void)addDivider:(NSString *)css height:(CGFloat)height;
		[Export("addDivider:height:")]
		void AddDivider(string css, nfloat height);

		// -(void)onHighlight:(IView *)view atIndex:(NSUInteger)index;
		[Export("onHighlight:atIndex:")]
		void OnHighlight(IView view, nuint index);

		// -(void)onUnhighlight:(IView *)view atIndex:(NSUInteger)index;
		[Export("onUnhighlight:atIndex:")]
		void OnUnhighlight(IView view, nuint index);

		// -(void)onClick:(IView *)view atIndex:(NSUInteger)index;
		[Export("onClick:atIndex:")]
		void OnClick(IView view, nuint index);

		// -(void)onRefresh:(IRefreshControl *)refreshControl state:(IRefreshState)state;
		[Export("onRefresh:state:")]
		void OnRefresh(IRefreshControl refreshControl, IRefreshState state);

		// -(void)endRefresh:(IRefreshControl *)refreshControl;
		[Export("endRefresh:")]
		void EndRefresh(IRefreshControl refreshControl);

		// -(void)addSeparator:(NSString *)css;
		[Export("addSeparator:")]
		void AddSeparator(string css);

		// -(void)addSeparator:(NSString *)css height:(CGFloat)height;
		[Export("addSeparator:height:")]
		void AddSeparator(string css, nfloat height);

		// -(void)onHighlight:(IView *)view;
		[Export("onHighlight:")]
		void OnHighlight(IView view);

		// -(void)onUnhighlight:(IView *)view;
		[Export("onUnhighlight:")]
		void OnUnhighlight(IView view);

		// -(void)onClick:(IView *)view;
		[Export("onClick:")]
		void OnClick(IView view);
	}

	// @interface ITableRow : IView
	[BaseType(typeof(IView))]
	interface ITableRow
	{
		// -(id)initWithNumberOfColumns:(NSUInteger)num;
		[Export("initWithNumberOfColumns:")]
		IntPtr Constructor(nuint num);

		// -(void)column:(NSUInteger)column setText:(NSString *)text;
		[Export("column:setText:")]
		void Column(nuint column, string text);

		// -(IView *)columnView:(NSUInteger)column;
		[Export("columnView:")]
		IView ColumnView(nuint column);
	}

	// @interface ILabel : IView
	[BaseType(typeof(IView))]
	interface ILabel
	{
		// @property (readonly, nonatomic) UILabel * label;
		[Export("label")]
		UILabel Label { get; }

		// @property (nonatomic) NSString * text;
		[Export("text")]
		string Text { get; set; }

		// @property (nonatomic) NSAttributedString * attributedText;
		[Export("attributedText", ArgumentSemantic.Assign)]
		NSAttributedString AttributedText { get; set; }

		// +(ILabel *)labelWithText:(NSString *)text;
		[Static]
		[Export("labelWithText:")]
		ILabel LabelWithText(string text);
	}

	// @interface ISwitch : IView
	[BaseType(typeof(IView))]
	interface ISwitch
	{
		// @property (readonly, nonatomic) UISwitch * uiswitch;
		[Export("uiswitch")]
		UISwitch Uiswitch { get; }

		// @property (getter = isOn, nonatomic) BOOL on;
		[Export("on")]
		bool On { [Bind("isOn")] get; set; }

		// -(void)setOn:(BOOL)on animated:(BOOL)animated;
		[Export("setOn:animated:")]
		void SetOn(bool on, bool animated);
	}

	// @interface IPullRefresh : NSObject <UIScrollViewDelegate>
	[BaseType(typeof(NSObject))]
	interface IPullRefresh : IUIScrollViewDelegate
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		NSObject Delegate { get; set; }

		// @property (nonatomic, weak) id _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic) IView * headerView;
		[Export("headerView", ArgumentSemantic.Assign)]
		IView HeaderView { get; set; }

		// @property (nonatomic) IView * footerView;
		[Export("footerView", ArgumentSemantic.Assign)]
		IView FooterView { get; set; }

		// @property (nonatomic) IRefreshTriggerMode headerTriggerMode;
		[Export("headerTriggerMode", ArgumentSemantic.Assign)]
		IRefreshTriggerMode HeaderTriggerMode { get; set; }

		// @property (nonatomic) IRefreshTriggerMode footerTriggerMode;
		[Export("footerTriggerMode", ArgumentSemantic.Assign)]
		IRefreshTriggerMode FooterTriggerMode { get; set; }

		// @property (nonatomic) CGFloat headerVisibleRateToRefresh;
		[Export("headerVisibleRateToRefresh")]
		nfloat HeaderVisibleRateToRefresh { get; set; }

		// @property (nonatomic) CGFloat footerVisibleRateToRefresh;
		[Export("footerVisibleRateToRefresh")]
		nfloat FooterVisibleRateToRefresh { get; set; }

		// -(id)initWithScrollView:(UIScrollView *)scrollView;
		[Export("initWithScrollView:")]
		IntPtr Constructor(UIScrollView scrollView);

		// -(void)scrollViewDidEndDragging:(UIScrollView *)scrollView willDecelerate:(BOOL)decelerate;
		[Export("scrollViewDidEndDragging:willDecelerate:")]
		void ScrollViewDidEndDragging(UIScrollView scrollView, bool decelerate);

		// -(void)scrollViewDidScroll:(UIScrollView *)scrollView;
		[Export("scrollViewDidScroll:")]
		void ScrollViewDidScroll(UIScrollView scrollView);

		// -(void)endRefresh:(IView *)view;
		[Export("endRefresh:")]
		void EndRefresh(IView view);

		// -(void)beginHeaderRefresh;
		[Export("beginHeaderRefresh")]
		void BeginHeaderRefresh();

		// -(void)beginFooterRefresh;
		[Export("beginFooterRefresh")]
		void BeginFooterRefresh();
	}

	// @protocol IPullRefreshDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IPullRefreshDelegate
	{
		// @required -(void)onRefresh:(IView *)view state:(IRefreshState)state;
		[Abstract]
		[Export("onRefresh:state:")]
		void State(IView view, IRefreshState state);
	}

	// @interface IRefreshControl : IView
	[BaseType(typeof(IView))]
	interface IRefreshControl
	{
		// @property (readonly, nonatomic) IView * indicatorView;
		[Export("indicatorView")]
		IView IndicatorView { get; }

		// @property (readonly, nonatomic) IView * contentView;
		[Export("contentView")]
		IView ContentView { get; }

		// @property (nonatomic) IRefreshState state;
		[Export("state", ArgumentSemantic.Assign)]
		IRefreshState State { get; set; }

		// -(void)setStateTextForNone:(NSString *)none maybe:(NSString *)maybe begin:(NSString *)begin;
		[Export("setStateTextForNone:maybe:begin:")]
		void SetStateTextForNone(string none, string maybe, string begin);
	}

	// @interface IPopover : IView
	[BaseType(typeof(IView))]
	interface IPopover
	{
		// -(void)presentView:(IView *)view onView:(UIView *)containerView;
		[Export("presentView:onView:")]
		void PresentView(IView view, UIView containerView);

		// -(void)presentView:(IView *)view onViewController:(UIViewController *)controller;
		[Export("presentView:onViewController:")]
		void PresentView(IView view, UIViewController controller);
	}
}
