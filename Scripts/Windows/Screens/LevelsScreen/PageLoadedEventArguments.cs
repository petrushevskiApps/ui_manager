using System;

public class PageLoadedEventArguments : EventArgs
{
    public int ElementsInPage { get; }

    public int IndexOfLastCompletedLevel { get; }

    public PageLoadedEventArguments(int indexOfLastCompletedLevel, int elementsInPage)
    {
        IndexOfLastCompletedLevel = indexOfLastCompletedLevel;
        ElementsInPage = elementsInPage;
    }
}