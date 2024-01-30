using System.Collections;
using UnityEngine;

public class WallMovement : MonoBehaviour
{

    [SerializeField] private GameObject[] grassArray = { };
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject endPoint;
    private Coroutine grassControl;
    private int grassIndex = 0;

    public void Start()
    {
        if (grassControl != null)
            StopCoroutine(grassControl);

        grassControl = StartCoroutine(StartMovingObstacles());
    }

    public void DisableAll()
    {
        StopCoroutine(grassControl);
        foreach (GameObject obj in grassArray)
        {
            obj.GetComponent<Grass>().StopMovement();
        }
    }

    private void VerifyDistance(GameObject[] grassArray)
    {
        foreach (GameObject obj in grassArray)
        {
            if (obj.transform.position.x < endPoint.transform.position.x)
            {
                obj.transform.position = spawnPoint.transform.position;
            }
        }
    }

    private IEnumerator StartMovingObstacles()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(.8f);
            VerifyDistance(grassArray);
        }
    }
}
