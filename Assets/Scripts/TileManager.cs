using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Tiles;
    [SerializeField] private GameObject[] spawnObjects;

    private float spawnZ = -20f;
    private int previousTile = 0;

    private readonly float size = 20f;
    private readonly int tileOnScreen = 5;
    private readonly float safeZone = 25f;

    private Transform playerTransform;
    private List<GameObject> activeTiles;

    // Start is called before the first frame update
    void Start()
    {
      
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        // To spawn Few Tiles at the beginning
        for (int i = 0; i < tileOnScreen; i++) { 
            if(i < 2) // To spawn plain tile intially
            {
                SpawnTile(0);
            }
            else { SpawnTile(); }
        }

    }

    // Update is called once per frame
    void Update()
    {        
        if (playerTransform.position.z - safeZone > (spawnZ - tileOnScreen * size)){
            SpawnTile();
            DeleteTile();
        }
    }
    // To active spawn tile function and add int the game
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if(prefabIndex == -1 ) {
            go = Instantiate(Tiles[RandomTile()]) as GameObject;
        }
        else
        {
            go = Instantiate(Tiles[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += size;
        activeTiles.Add(go);
    }
    // Removes the tile passed
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    // Random Tile found to be spawned and makes sure two consecutive tiles are not same
    private int RandomTile()
    {
        if (Tiles.Length <= 1)
        {
            return 0;
        }

        //int rand = Random.Range(0, Tiles.Length);
        //return rand;
        int randomIndex = previousTile;
        while (randomIndex == previousTile)
        {
            randomIndex = Random.Range(0, Tiles.Length);
        }
        previousTile = randomIndex;
        return randomIndex;
    }

    // Spawning of the health supply 
   public void SpawnObj()
    {
       Transform pos = GameObject.FindGameObjectWithTag("Player").transform;

        int randomIndex = Random.Range(0, spawnObjects.Length);
        Vector3 randomSpawnPosition = new (Random.Range(-1, 2),0.5f, pos.position.z + 10f);
        Instantiate(spawnObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
       
    }

}

