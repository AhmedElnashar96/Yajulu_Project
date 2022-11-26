using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolGameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    [SerializeField] private BoolGameEvent gameEvent;
    [Tooltip("Event to register with.")]
    [SerializeField] private BooleanEvent response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(bool value)
    {
        response.Invoke(value);
    }
}
