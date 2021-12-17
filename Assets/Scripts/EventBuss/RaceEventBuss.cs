using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventBuss
{
    public class RaceEventBuss
    {

        public static readonly IDictionary<RaceEventType, UnityEvent> Events =
            new Dictionary<RaceEventType, UnityEvent>();

        public static void Subscribe(RaceEventType eventType, UnityAction listener)
        {
            UnityEvent thisEvent;

            if (Events.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Events.Add(eventType,thisEvent);
            }
        }

        public static void UnSubscribe(RaceEventType eventType, UnityAction listener)
        {

            UnityEvent thisEvent;
            
            if (Events.TryGetValue(eventType,out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void Publish(RaceEventType eventType)
        {
            UnityEvent thisEvent;
            if (Events.TryGetValue(eventType,out thisEvent))
            {
                thisEvent?.Invoke();
            }
        }


    }
}