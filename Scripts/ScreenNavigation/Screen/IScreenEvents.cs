using System;

public interface IScreenEvents
{
    event EventHandler ScreenShownEvent;
    event EventHandler ScreenResumedEvent;
    event EventHandler ScreenHiddenEvent;
    event EventHandler ScreenClosedEvent;
}