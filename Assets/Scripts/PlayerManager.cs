using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Button testButton;


    private void Start()
    {
        AssetsDatabase assetsDatabase = new AssetsDatabase();
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        GameObject go = Instantiate(AssetsDatabase.prefabsDict["Player"] , Vector3.zero, Quaternion.identity);
        Player player = go.GetComponent<Player>();
        //TODO: Comunicate with input -- THIS LINA BELOW IS FOR TESTING ONLY.
        testButton.onClick.AddListener(player.JumpAction);
        
    }

    
}
