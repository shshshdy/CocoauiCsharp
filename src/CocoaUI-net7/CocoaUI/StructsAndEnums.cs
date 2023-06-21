namespace CocoaUiBinding
{
    public enum IEventType : uint
    {
        Unhighlight = 1 << 0,
        Highlight = 1 << 1,
        Click = 1 << 2,
        Tap = Click,
        Change = 1 << 3,
        Return = 1 << 4
    }

    public enum IRefreshState : uint
    {
        None,
        Maybe,
        Begin
    }

    public enum IRefreshTriggerMode : uint
    {
        Pull,
        Scroll
    }
}