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
            gameObject.transform.position += Vector3.left * speed;
            yield return new WaitForSeconds(speed);
        }
    }
    private void OnEnable()
    {
        if (movement == null)
        {
            movement = StartCoroutine(StartMoving());
        }
        else
        {
            StopCoroutine(movement);
            movement = StartCoroutine(StartMoving());
        }
    }

    private void OnDisable()
    {
        StopCoroutine(movement);
    }
}
