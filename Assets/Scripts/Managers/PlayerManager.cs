using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private EventHandler eventHandler;
    Player player;

    public void Init(string prefabName)
    {
        SpawnPlayer(prefabName);
    }

    private void SpawnPlayer(string prefabName)
    {
        GameObject go = Instantiate(AssetsDatabase.prefabsDict[prefabName], Vector3.zero, Quaternion.identity);
        player = go.GetComponent<Player>();
        player.SetupPlayer(eventHandler);
    }
}
