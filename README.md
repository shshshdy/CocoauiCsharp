# CocoauiCsharp
binding cocoaui <br/>

查看包构架<br/>
```sh
xcrun -sdk iphoneos lipo -info libcocoaui.a
```
合并包<br/>
```sh
xcrun -sdk iphoneos lipo -create -output libcocoaui.a simulator/libcocoaui.a iphone/libcocoaui.a
```

thanks ideawu <br/>
<a href="https://github.com/ideawu/cocoaui">https://github.com/ideawu/cocoaui</a> <br/>
<a href="http://www.cocoaui.com/">http://www.cocoaui.com/<a>

