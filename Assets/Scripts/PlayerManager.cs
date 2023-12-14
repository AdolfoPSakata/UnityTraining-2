using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Button testButton;
    Player player;

    public void Init(string prefabName)
    {
       SpawnPlayer(prefabName);
    }

    private void SpawnPlayer(string prefabName)
    {
        GameObject go = Instantiate(AssetsDatabase.prefabsDict[prefabName] , Vector3.zero, Quaternion.identity);
        player = go.GetComponent<Player>();
        //TODO: Comunicate with input -- THIS LINE BELOW IS FOR TESTING ONLY.
        //testButton.onClick.AddListener(player.JumpAction);
        
    }

    public void SubscribePlayer(Action onPlayerDied)
    {
         player.Died += onPlayerDied;
    }
    
}
