using System;

internal class SubscriptionPropertyWhithParameter<T> : ISubscriptionPropertyWhithParameter<T>
{
    private T _value;
    private Action<T> _onChangeValue;
    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            _onChangeValue?.Invoke(_value);
        }

    }

    public void SunscribeOnChange(Action<T> subscriptionAction)
    {
        _onChangeValue += subscriptionAction;
    }

    public void UnSubscribeOnChange(Action<T> unSubscriptionAction)
    {
        _onChangeValue -= unSubscriptionAction;
    }
}