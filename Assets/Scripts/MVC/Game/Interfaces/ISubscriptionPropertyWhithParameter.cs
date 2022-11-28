using System;

internal interface ISubscriptionPropertyWhithParameter<out T>
{
    T Value { get; }
    void SunscribeOnChange(Action<T> subscriptionAction);
    void UnSubscribeOnChange(Action<T> unSubscriptionAction);
}