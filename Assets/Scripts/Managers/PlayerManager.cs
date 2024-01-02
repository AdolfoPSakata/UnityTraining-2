using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private EventHandler eventHandler;
    Player player;

    public void Setup(string prefabName)
    {
        SpawnPlayer(prefabName);
    }

    public void Init()
    {
        player.InitPlayer();
    }

    private void SpawnPlayer(string prefabName)
    {
        GameObject go = Instantiate(AssetsDatabase.prefabsDict[prefabName], Vector3.zero, Quaternion.identity);
        player = go.GetComponent<Player>();
        player.SetupPlayer(eventHandler);
    }
}
