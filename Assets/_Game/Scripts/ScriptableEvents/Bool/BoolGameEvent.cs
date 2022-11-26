using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class BooleanEvent : UnityEvent<bool> { }

[CreateAssetMenu(fileName = "BooleanGameEvent", menuName = "Events/ Boolean Game Event")]
public class BoolGameEvent : ScriptableObject
{
    private List<BoolGameEventListener> listeners = new List<BoolGameEventListener>();

    public void Raise(bool value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(BoolGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(BoolGameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
