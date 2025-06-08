using System;

namespace TwoOneTwoGames.UIManager.Utilities.ReactiveProperty
{
    public interface IReadOnlyReactiveProperty<out T>
    {
        void Subscribe(Action<T> onValueChangeListener, bool triggerOnSubscribe = true);
        void Unsubscribe(Action<T> onValueChangeListener);
    }
}