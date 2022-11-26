using UnityEngine;

public class IntGameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    [SerializeField] private IntGameEvent gameEvent;
    [Tooltip("Event to register with.")]
    [SerializeField] private IntegerEvent response;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(int value)
    {
        response.Invoke(value);
    }
}
