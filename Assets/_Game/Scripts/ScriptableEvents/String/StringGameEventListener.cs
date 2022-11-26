using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringGameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    [SerializeField] private StringGameEvent gameEvent;
    [Tooltip("Event to register with.")]
    [SerializeField] private StringEvent response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(string value)
    {
        response.Invoke(value);
    }
}
