using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public Action OnAddedPoints;
    public Action OnJump;
    public Action OnDied;

    [SerializeField] private Rigidbody2D rb;
    private float jumpForce;

    [Header("SPRITES")]
    [SerializeField] private SpriteRenderer head;
    [SerializeField] private SpriteRenderer body;
    [SerializeField] private SpriteRenderer wing_L;
    [SerializeField] private SpriteRenderer wing_R;
    [SerializeField] private SpriteRenderer tail;

    [SerializeField] private ParticleSystem blood;

    [SerializeField] private Animator animator;


    private EventHandler eventHandler;

    public void SetupPlayer(EventHandler eventHandler)
    {
        this.eventHandler = eventHandler;
        OnJump = Jump;
        OnDied = Die;
        eventHandler.AddEventToDict("OnDied", OnDied);
        eventHandler.AddEventToDict("OnAddedPoints", OnAddedPoints);
        eventHandler.AddEventToDict("OnJump", OnJump);
        SetPlayerData(PlayerPrefs.GetString("DUCK", "DUCK"));

    }

    public void InitPlayer()
    {
        rb.simulated = true;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Die()
    {
        rb.simulated = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            eventHandler.SendAction("OnDied");
            blood.Play();
            animator.SetBool("IsDead", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            eventHandler.SendAction("OnAddedPoints");
        }
    }

    private void SetPlayerData(string key)
    {
        print(key);
        ScriptableObject so = ReadScriptables.GetScriptableObject(key);
        if (so.GetType() == typeof(PlayerData))
        {
            PlayerData playerData = (PlayerData)so;
            jumpForce = playerData.jumpForce;

            head.sprite = playerData.head;
            body.sprite = playerData.body;
            wing_L.sprite = playerData.wings;
            wing_R.sprite = playerData.wings;
            tail.sprite = playerData.tail;
        }

    }
}
