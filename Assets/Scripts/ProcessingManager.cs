using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class ProcessingManager : MonoBehaviour
{
    Action PlayerOnThePill;
    Camera camera;
    [SerializeField] private EventHandler eventHandler;
    [SerializeField] private PostProcessVolume volume;

    [SerializeField] private Vignette vg;
    [SerializeField] private ChromaticAberration ca;

    private void Start ()
    {
        camera = Camera.main;
        PlayerOnThePill = StartAberration;
        eventHandler.AddEventToDict("PlayerOnThePill", PlayerOnThePill);
        eventHandler.SubscribeToEvent("PlayerOnThePill", "OnPill");
        volume.profile.TryGetSettings<ChromaticAberration>(out ca);
        volume.profile.TryGetSettings<Vignette>(out vg);
    }

    private void StartAberration()
    {
        camera.orthographicSize = camera.orthographicSize * -1;
        ca.intensity.value = 1;
        Debug.Log("ParKUr");
    }
}
