// 警告: 此功能已弃用。请改用“本机引用”文件夹。
// 右键单击“本机引用”文件夹，选择“添加本机引用”，
// 然后选择要绑定的静态库或框架。
//
// 添加静态库或框架后，右键单击该库或
// 框架并选择“属性”以更改 LinkWith 值。

using ObjCRuntime;

[assembly: LinkWith ("libcocoaui.a", SmartLink = true, ForceLoad = true)]
