using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public Action OnAddedPoints;
    public Action OnJump;
    public Action OnDied;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    private ScreenInputMap inputSystem;
    private EventHandler eventHandler;

    public void SetupPlayer(EventHandler eventHandler)
    {
        this.eventHandler = eventHandler;
        //rb = gameObject.GetComponent<Rigidbody2D>();
        OnJump = Jump;
        OnDied = Die;

        eventHandler.AddEventToDict("OnDied", OnDied);
        eventHandler.AddEventToDict("OnAddedPoints", OnAddedPoints);
        eventHandler.AddEventToDict("OnJump", OnJump);
      
        //--------------------------------------
       
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Die()
    {
        inputSystem.ScreenInput.Tap.Disable();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            eventHandler.SendAction("OnDied");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            eventHandler.SendAction("OnAddedPoints");
        }
    }
}
