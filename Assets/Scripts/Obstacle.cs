using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Coroutine movement;

    [SerializeField] private GameObject endPoint;
    [SerializeField] private float speed;

    private IEnumerator StartMoving()
    {
        while (true)
        {
            gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
            yield return null;
        }
    }

    public void StopMovement()
    {
        StopCoroutine(movement);
    }

    private void PositionRandomizer()
    {
        float xPosition = gameObject.transform.position.x;
        float yPosition = Random.Range(-2.8f, 2.8f);
        gameObject.transform.position = new Vector3(xPosition, yPosition, 0);
    }

    private void OnEnable()
    {
        PositionRandomizer();
        if (movement != null)
            StopCoroutine(movement);

        movement = StartCoroutine(StartMoving());
    }

    private void OnDisable()
    {
        StopMovement();
    }
}
