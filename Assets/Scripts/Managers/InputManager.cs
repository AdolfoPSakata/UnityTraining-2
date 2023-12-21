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

        inputSystem.ScreenInput.Click.started += context => eventHandler.SendAction("OnJump");
    }
    public void Init()
    { 
        inputSystem.ScreenInput.Click.Enable();
        //inputSystem.ScreenInput.UI.Disable();
    }
    
    private void Stop()
    {
        inputSystem.ScreenInput.Click.Disable();
        //inputSystem.ScreenInput.UI.Enable();
    }
}
