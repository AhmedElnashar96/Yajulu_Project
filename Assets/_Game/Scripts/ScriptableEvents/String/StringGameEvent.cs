using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class StringEvent : UnityEvent<string> { }

[CreateAssetMenu(fileName = "StringGameEvent", menuName = "Events/String Game Event")]
public class StringGameEvent : ScriptableObject
{
    private List<StringGameEventListener> listeners = new List<StringGameEventListener>();

    public void Raise(string value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(StringGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(StringGameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
