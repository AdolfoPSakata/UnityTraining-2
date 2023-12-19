using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    private Coroutine movement;

    [SerializeField] private float speed;

    private void Awake()
    {
        if (movement != null)
            StopCoroutine(movement);

        movement = StartCoroutine(StartMoving());
    }

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
}
