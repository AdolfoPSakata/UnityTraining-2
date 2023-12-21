using System.Collections;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private int maxObstacles = 20;
    [SerializeField] private int enableInterval = 1;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject endPoint;
    private GameObject[] obstacles;
    private GameObject obstacle;
    private Coroutine obstacleControl;
    private int obstacleIndex = 0;

    public void Init(string prefabName)
    {
        obstacle = AssetsDatabase.prefabsDict[prefabName];
        SpawnObjects(obstacle);
        if (obstacleControl != null)
            StopCoroutine(obstacleControl);

        obstacleControl = StartCoroutine(StartMovingObstacles());
    }
    private void SpawnObjects(GameObject obstacle)
    {
        obstacles = new GameObject[maxObstacles];
        for (int i = 0; i < maxObstacles; i++)
        {
            GameObject obj = Instantiate(obstacle);
            obj.transform.parent = gameObject.transform;
            obj.SetActive(false);
            obstacles[i] = obj;
        }
    }

    private void DisableObstacle(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void DisableAll()
    {
        StopCoroutine(obstacleControl);
        foreach (GameObject obj in obstacles)
        {
            obj.GetComponent<Obstacle>().StopMovement();
        }
    }

    private void EnableObstacle(int index)
    {
        GameObject currentObstacle = obstacles[index];
        currentObstacle.transform.position = spawnPoint.transform.position;
        currentObstacle.SetActive(true);

    }

    private void VerifyDistance(GameObject[] obstacles)
    {
        foreach (GameObject obj in obstacles)
        {
            if (obj.activeInHierarchy && obj.transform.position.x < endPoint.transform.position.x)
            {
                print(obj.transform.position.x < endPoint.transform.position.x);
                DisableObstacle(obj);
            }
        }
    }

    private int SelectNextIndex(int index, int maxObstacles)
    {
        if (index >= maxObstacles - 1)
            index = 0;
        else
            index++;
        return index;
    }

    private IEnumerator StartMovingObstacles()
    {
        while (true)
        {
            EnableObstacle(obstacleIndex);
            yield return new WaitForSecondsRealtime(enableInterval);
            VerifyDistance(obstacles);
            obstacleIndex = SelectNextIndex(obstacleIndex, maxObstacles);
        }
    }
}
