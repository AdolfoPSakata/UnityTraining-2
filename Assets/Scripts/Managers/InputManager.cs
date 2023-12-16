using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    [SerializeField] private EventHandler eventHandler;
    private ScreenInputMap inputSystem;
    Action OnPlayerDefeat;

    public void Init()
    {
        inputSystem = new ScreenInputMap();
        OnPlayerDefeat = Stop;
        eventHandler.AddEventToDict("OnPlayerDefeat", OnPlayerDefeat);
        eventHandler.SubscribeToEvent("OnPlayerDefeat", "OnDied");

        inputSystem.Enable();
        inputSystem.ScreenInput.Tap.started += context => eventHandler.SendAction("OnJump");
    }

    private void Stop()
    {
        inputSystem.ScreenInput.Tap.Disable();
    }
}
