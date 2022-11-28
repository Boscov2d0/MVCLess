using System;
internal interface ISubscriptionProperty<out T>
{
     T Value { get; }
    void SubscribeOnChange(Action subscriptionAction);
    void UnSubscribeOnChange(Action unSubscriptionAction);
}