using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensManager : MonoBehaviour
{

    [SerializeField] private int enableInterval = 10;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject endPoint;
    private List<GameObject> itensList = new List<GameObject>();
    private GameObject item;
    private Coroutine itemControl;

    public void Setup(string prefabName)
    {
        item = AssetsDatabase.prefabsDict[prefabName];
    }

    public void Init()
    {
        if (itemControl != null)
            StopCoroutine(itemControl);

        itemControl = StartCoroutine(StartMoving());
    }

    private void SpawnObjects(GameObject item)
    {
        GameObject obj = Instantiate(item);
        int index = Random.Range(0, spawnPoints.Length);
        obj.transform.parent = gameObject.transform;
        obj.transform.position = spawnPoints[index].transform.position;
        obj.GetComponent<Food>().Setup();
    }

    private void DisableObstacle(GameObject obj)
    {
        Destroy(obj);
    }

    public void DisableAll()
    {
        StopCoroutine(itemControl);

        foreach (GameObject obj in itensList)
        {
            obj.GetComponent<Food>().StopMovement();
        }
    }

    private void VerifyDistance(List<GameObject> itensArray)
    {
        if (itensArray.Count <= 0)
            return;
        foreach (GameObject obj in itensArray)
        {
            if (obj.transform.position.x < endPoint.transform.position.x)
            {
                DisableObstacle(obj);
            }
        }
    }

    private IEnumerator StartMoving()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(enableInterval);
            SpawnObjects(item);
            VerifyDistance(itensList);
            Debug.Log("Food Spawned");
        }
    }
}

