using System;

namespace MenuManager.Scripts.Utilitis
{
    public class ReactiveProperty<T> : IReactiveProperty<T>
    {
        private T _value;
    
        public T Value
        {
            get => _value;
            set
            {
                if (Equals(_value, value))
                {
                    return;
                }
                _value = value;
                ValueChanged?.Invoke(_value);
            }
        }

        public event Action<T> ValueChanged;

        public ReactiveProperty(T initialValue = default)
        {
            _value = initialValue;
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