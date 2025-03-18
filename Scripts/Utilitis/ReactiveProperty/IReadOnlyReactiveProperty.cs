using System;

namespace MenuManager.Scripts.Utilitis
{
    public interface IReadOnlyReactiveProperty<out T>
    {
        void Subscribe(Action<T> onValueChangeListener, bool triggerOnSubscribe = true);
        void Unsubscribe(Action<T> onValueChangeListener);
    }
}