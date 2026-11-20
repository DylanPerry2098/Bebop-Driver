using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class EventBus
{
    public static readonly Dictionary<Type, List<Delegate>> EventSubscriptions = new Dictionary<Type, List<Delegate>>();

    public static void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : class
    {
        var eventType = typeof(TEvent);
        if (!EventSubscriptions.ContainsKey(eventType))
        {
            EventSubscriptions[eventType] = new List<Delegate>();
        }
        EventSubscriptions[eventType].Add(handler);
    }

    public static void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : class
    {
        var eventType = typeof(TEvent);
        if (EventSubscriptions.ContainsKey(eventType))
        {
            EventSubscriptions[eventType].Remove(handler);
            if (EventSubscriptions[eventType].Count == 0)
            {
                EventSubscriptions.Remove(eventType);
            }
        }
    }

    public static void Publish<TEvent>(TEvent eventItem) where TEvent : class
    {
        var eventType = typeof(TEvent);

        if (!EventSubscriptions.TryGetValue(eventType, out var handlers))
        {
            handlers = new List<Delegate>();
            EventSubscriptions[eventType] = handlers;
        }

        foreach (var handler in EventSubscriptions[eventType].Cast<Action<TEvent>>())
        {
            handler.Invoke(eventItem);
        }
    }
}
