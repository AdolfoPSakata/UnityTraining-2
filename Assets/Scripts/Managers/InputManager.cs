using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    [SerializeField] private EventHandler eventHandler;
    private ScreenInputMap inputSystem;
    Action OnPlayerDefeat;

    public void Setup()
    {
        inputSystem = new ScreenInputMap();
        OnPlayerDefeat = Stop;
        eventHandler.AddEventToDict("OnPlayerDefeat", OnPlayerDefeat);
        eventHandler.SubscribeToEvent("OnPlayerDefeat", "OnDied");
       
        inputSystem.ScreenInput.Tap.started += context => eventHandler.SendAction("OnJump");
    }

    public void Init()
    { 
        inputSystem.Enable();
    }
    
    private void Stop()
    {
        inputSystem.ScreenInput.UI.Enable();
        inputSystem.ScreenInput.Tap.Disable();
    }
}
