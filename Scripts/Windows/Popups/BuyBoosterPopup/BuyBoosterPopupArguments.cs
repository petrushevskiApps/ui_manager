using System;
using UnityEngine;

namespace TwoOneTwoGames.UIManager.Windows.Popups
{
    public struct BuyBoosterPopupArguments
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

        public int ResourceId { get; }
        public int BoosterCost { get; }
        public int BoosterResourceId { get; }

        public Action ONSuccessfulBuy { get; }

        public BuyBoosterPopupArguments(
            string title, 
            string message, 
            Sprite icon,
            Action discardAction, 
            int boosterResourceId, 
            int resourceId,
            int boosterCost, 
            Action onSuccessfulBuy)
        {
            Title = title;
            Message = message;
            ResourceId = resourceId;
            BoosterCost = boosterCost;
            ONSuccessfulBuy = onSuccessfulBuy;
            BoosterResourceId = boosterResourceId;
            Icon = icon;
            DiscardAction = discardAction;
        }
    }
}