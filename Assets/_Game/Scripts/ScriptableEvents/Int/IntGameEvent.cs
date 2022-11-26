using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntegerEvent : UnityEvent<int> { }

[CreateAssetMenu(fileName = "IntGameEvent", menuName = "Events/ Integer Game Event")]
public class IntGameEvent : ScriptableObject
{
    private List<IntGameEventListener> listeners = new List<IntGameEventListener>();

    public void Raise(int value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(IntGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(IntGameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
