﻿namespace PassthroughBehaviorDemo.Controls;

public static class BehaviorAttachment
{
    public static readonly BindableProperty PassthroughBehaviorProperty =
        BindableProperty.CreateAttached(
            "PassthroughBehavior",
            typeof(Behavior),
            typeof(BehaviorAttachment),
            null,
            propertyChanged: OnBehaviorChanged);

    public static void SetPassthroughBehavior(BindableObject view, Behavior value)
    {
        view.SetValue(PassthroughBehaviorProperty, value);
    }

    public static Behavior GetPassthroughBehavior(BindableObject view)
    {
        return (Behavior)view.GetValue(PassthroughBehaviorProperty);
    }

    static void OnBehaviorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue is Behavior newBehavior)
        {
            if (bindable is CustomEntry customEntry)
            {
                var entry = customEntry.FindByName<Entry>("WrappedEntry");
                if (entry != null)
                {
                    entry.Behaviors.Add(newBehavior);
                }
            }
        }
    }
}