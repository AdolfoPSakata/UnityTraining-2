using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Coroutine movement;

    [SerializeField] private GameObject endPoint;
    [SerializeField] private float speed;
    [Header("SPRITES")]
    [SerializeField] private SpriteRenderer up;
    [SerializeField] private SpriteRenderer down;
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
        //TODO: change to fit the screen
        float yPosition = Random.Range(-2.8f, 2.8f);
        gameObject.transform.position = new Vector3(xPosition, yPosition, 0);
    }

    private void OnEnable()
    {
        SetObstacleData();
        PositionRandomizer();
        if (movement != null)
            StopCoroutine(movement);

        movement = StartCoroutine(StartMoving());
    }

    private void OnDisable()
    {
        StopMovement();
    }

    private void SetObstacleData()
    {
        int index = Random.Range(0, ReadScriptables.GetScriptablesCount());
        int count = ReadScriptables.GetScriptablesCount();

        ScriptableObject so = ReadScriptables.GetScriptableObject(index); ;

        if (so.GetType() != typeof(ObstacleData))
        {
            SetObstacleData();
            return;
        }

        ObstacleData obstacleData = (ObstacleData)so;
        speed = obstacleData.speed;
        up.sprite = obstacleData.sprite;
        down.sprite = obstacleData.sprite;
    }
}
