using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int jumpForce = 200;
    Player(Rigidbody2D rb)
    {
        this.rb = rb;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        IEnumerator test = JumpTest();
        if (test != null)
        {
            StopCoroutine(test);
        }
        StartCoroutine(test);
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            //TODO: Change this for not destroy Player, yet
            //Destroy(this.gameObject);
        }
    }

    IEnumerator JumpTest()
    {
        while (true)
        {
            Jump();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
