using System.Collections.Generic;
using UnityEngine;

public class CollectibleFactory : MonoBehaviour
{
    [SerializeField] private GameObject collectiblePrefab;

    private readonly Vector2[] spawnPositions =
    {
        new (-4f, 2f),
        new (4f, 2f),
        new (0f, 3f),
        new (-4f, -2f),
        new (4f, -2f)
    };

    //Track spawned collectibles for resets.
    private readonly List<GameObject> spawnedCollectibles =
        new();

    private void Start()
    {
        SpawnCollectibles();
    }

    //Factory: Spawn collectibles from a prefab.
    public void SpawnCollectibles()
    {
        foreach (Vector2 position in spawnPositions)
        {
            GameObject collectible = Instantiate(
                collectiblePrefab,
                position,
                Quaternion.identity
            );

            spawnedCollectibles.Add(collectible);
        }
    }

    //Clear remaining collectibles and respawn.
    public void ResetCollectibles()
    {
        foreach (GameObject collectible in spawnedCollectibles)
        {
            if (collectible != null)
                Destroy(collectible);
        }

        spawnedCollectibles.Clear();
        SpawnCollectibles();
    }
}