using System;

internal class SubscriptionProperty<T>
{
    private T _value;
    private Action _onChangeValue;
    private Action<T> _onChangeValueWhithParameter;
    public T Value
    {
        get => _value; 
        set 
        {
            _value = value;
            _onChangeValue?.Invoke();
            _onChangeValueWhithParameter?.Invoke(_value);
        }

    }

    public void SubscribeOnChange(Action subscriptionAction) 
    {
        _onChangeValue += subscriptionAction;
    }

    public void UnSubscribeOnChange(Action unSubscriptionAction) 
    {
        _onChangeValue -= unSubscriptionAction;
    }
    public void SunscribeOnChangeWhithParameter(Action<T> subscriptionAction)
    {
        _onChangeValueWhithParameter += subscriptionAction;
    }

    public void UnSubscribeOnChangeWhithParameter(Action<T> unSubscriptionAction)
    {
        _onChangeValueWhithParameter -= unSubscriptionAction;
    }
}