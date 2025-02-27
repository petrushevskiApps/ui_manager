using System;

namespace MenuManager.Scripts.Utilitis
{
    public interface IReadOnlyReactiveProperty<T>
    {
        void Subscribe(Action<T> onValueChangeListener);
        void Unsubscribe(Action<T> onValueChangeListener);
    }
}