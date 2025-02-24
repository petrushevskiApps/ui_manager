using System;

public interface IPopupScreenEvents
{
    event EventHandler PopupScreenShownEvent;
    event EventHandler PopupScreenResumedEvent;
    event EventHandler PopupScreenHiddenEvent;
    event EventHandler PopupScreenClosedEvent;
}