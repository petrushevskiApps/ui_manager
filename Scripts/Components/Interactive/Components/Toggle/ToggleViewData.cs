using System;

namespace TwoOneTwoGames.UIManager.Components.Interactive
{
    public record ToggleViewData : ViewData
    {
        public string Label { get; set; }
        public bool State { get; set; }
        public Action OnToggleStateChanged { get; set; }
    }
}