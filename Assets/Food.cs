using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    [SerializeField] private SpriteRenderer image;
    public string foodName { get; private set; }
    [SerializeField] private int speed = 1;
    private Coroutine movement;
   
    public void Setup() 
    {
        int index = Random.Range(0, ReadScriptables.GetFoodDataLenght());

        ScriptableObject so = ReadScriptables.GetFoodData(index);

        if (so.GetType() != typeof(FoodData))
        {
            Setup();
            return;
        }

        FoodData foodData = (FoodData)so;
        foodName = foodData.prefabName;
        image.sprite = foodData.food;


        if (movement != null)
            StopCoroutine(movement);

        movement = StartCoroutine(StartMoving());
    }

    private IEnumerator StartMoving()
    {
        print("Start moving");
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
