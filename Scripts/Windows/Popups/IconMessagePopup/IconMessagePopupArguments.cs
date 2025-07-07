using System;
using TwoOneTwoGames.UIManager.Components.Interactive;
using UnityEngine;

namespace TwoOneTwoGames.ZenRings.UserInterface.Windows
{
    public struct IconMessagePopupArguments
    {
        // Title of the Popup
        public string Title { get; }
        
        // Message to be shown in the content area of the popup.
        public string Message { get; }
        
        // Icon to be shown in the content area of the popup.
        public Sprite Icon { get; }
        
        // Action which will be invoked when popup is discarded.
        // Example for discarding is pressing Back button or
        // clicking on popup background.
        public Action DiscardAction { get; }
        
        // Array of buttons view data. Number of buttons which will
        // be presented in the popups button group depends on the amount
        // of data in this array.
        public UIButtonViewData[] ButtonsViewData { get; }
        
        public IconMessagePopupArguments(string title, string message, Sprite icon, Action discardAction, params UIButtonViewData[] buttonsViewData)
        {
            Title = title;
            Message = message;
            Icon = icon;
            DiscardAction = discardAction;
            ButtonsViewData = buttonsViewData;
        }
    }
}