using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    [SerializeField] private GameEvent gameEvent;
    [Tooltip("Event to register with.")]
    [SerializeField] private UnityEvent response;

    private void OnEnable() 
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        response.Invoke();
    }

    public void RegisterObject()
    {
        gameEvent.RegisterListener(this);
    }
}
