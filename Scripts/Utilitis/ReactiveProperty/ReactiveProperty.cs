using System;

namespace MenuManager.Scripts.Utilitis
{
    public class ReactiveProperty<T> : IReactiveProperty<T>
    {
        private T _value;
        private readonly bool _alwaysUpdate;

        public T Value
        {
            get => _value;
            set
            {
                if (!_alwaysUpdate && Equals(_value, value))
                {
                    return;
                }
                _value = value;
                ValueChanged?.Invoke(_value);
            }
        }

        public event Action<T> ValueChanged;

        public ReactiveProperty(T initialValue = default, bool alwaysUpdate = false)
        {
            _value = initialValue;
            _alwaysUpdate = alwaysUpdate;
        }

        public void Subscribe(Action<T> onValueChangeListener, bool triggerOnSubscribe = true)
        {
            ValueChanged += onValueChangeListener;
            if (triggerOnSubscribe)
            {
                onValueChangeListener?.Invoke(Value);
            }
        }

        public void Unsubscribe(Action<T> onValueChangeListener)
        {
            ValueChanged -= onValueChangeListener;
        }
    }
}