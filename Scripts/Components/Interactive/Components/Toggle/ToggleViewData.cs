using System;

namespace com.petrushevskiapps.menumanager
{
    public record ToggleViewData: ViewData
    {
        public string Label { get; set; }
        public bool State { get;  set; }
        public Action OnToggleStateChanged { get; set; }
    }
}