using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EvtSystem
{
    public class Event
    {

    }
    
    public class EventDispatcher
    {
        #region singleton

        private static EventDispatcher _instance = null;

        private EventDispatcher()
        {
        }

        public static EventDispatcher Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventDispatcher();
                }
                return _instance;
            }
        }
        #endregion

        public delegate void EventDelegate<T>(T e) where T : Event;

        private Dictionary<System.Type, System.Delegate> m_eventDelegates =
            new Dictionary<System.Type, System.Delegate>();

        private void _AddListener<T>(EventDelegate<T> listener) where T : Event
        {
            System.Type eventType = typeof(T);
            System.Delegate del;

            if(m_eventDelegates.TryGetValue(eventType, out del))
            {
                m_eventDelegates[eventType] = System.Delegate.Combine(del, listener);
            }
            else
            {
                m_eventDelegates[eventType] = listener;
            }
        }

        private void _RemoveListener<T>(EventDelegate<T> listener) where T : Event
        {
            System.Delegate del;
            if (m_eventDelegates.TryGetValue(typeof(T), out del))
            {
                System.Delegate newDel = System.Delegate.Remove(del, listener);

                if (newDel == null)
                {
                    m_eventDelegates.Remove(typeof(T));
                }
                else
                {
                    m_eventDelegates[typeof(T)] = newDel;
                }
            }
        }

        public void _Raise<T>(T evtData) where T : Event
        {
            System.Delegate del;
            if (m_eventDelegates.TryGetValue(typeof(T), out del))
            {
                EventDelegate<T> callback = del as EventDelegate<T>;
                if (callback != null)
                {
                    callback(evtData);
                }
            }
        }

        public static void Raise<T>(T evtData) where T : Event
        {
            Instance._Raise(evtData);
        }

        public static void AddListener<T>(EventDelegate<T> listener) where T : Event
        {
            Instance._AddListener(listener);
        }

        public static void RemoveListener<T>(EventDelegate<T> listener) where T : Event
        {
            Instance._RemoveListener(listener);
        }
    }
}
