using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject maskDudePrefab;
    public GameObject ninjaFrogPrefab;
    public GameObject pinkManPrefab;
    public GameObject virtualGuyPrefab;

    void Start()
    {
        GameObject prefabToSpawn = null;

        switch (GameSelection.chosenCharacter)
        {
            case "MaskDude": prefabToSpawn = maskDudePrefab; break;
            case "NinjaFrog": prefabToSpawn = ninjaFrogPrefab; break;
            case "PinkMan": prefabToSpawn = pinkManPrefab; break;
            case "VirtualGuy": prefabToSpawn = virtualGuyPrefab; break;
        }

        if (prefabToSpawn != null)
        {
            GameObject player = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
            GameManager.Instance.RegisterPlayer(player);
        }
    }
}
