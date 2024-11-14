using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;
     [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };
    [SerializeField] float appleSpawnChance = .3f;
    [SerializeField] float coinSpawnChance = .5f; 
    [SerializeField] float coinSeperationLength = 2f;
    LevelGenerator levelGenerator;
    ScoreManager scoreManager;
    List<int> availableLanes = new List<int> { 0, 1, 2 };

    void Start() 
    {
        SpawnFence();
        SpawnApple();
        SpawnCoin();
    }
    public void Init(LevelGenerator levelGenerator,ScoreManager scoreManager){
        this.levelGenerator = levelGenerator;   
        this.scoreManager = scoreManager;
    }
    void SpawnFence() 
    {
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;

            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }
    void SpawnApple(){
        if(Random.value > appleSpawnChance || availableLanes.Count <= 0) return;
        int selectedLane = SelectLane();

        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Apple newApple= Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Apple>();
        newApple.Init(levelGenerator);
    }
    void SpawnCoin(){
        if(Random.value > coinSpawnChance || availableLanes.Count <= 0) return;
        int selectedLane = SelectLane();

        int maxCoinToSpawn = 6;
        int cointToSpawn = Random.Range(1,maxCoinToSpawn);
        float topChunkZpos = transform.position.z + (coinSeperationLength * 2f);
        for(int i=0; i<cointToSpawn;i++){
            float spawnPositionZ = topChunkZpos - (i * coinSeperationLength); 
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPositionZ);
            Coin newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Coin>();
            newCoin.Init(scoreManager);
        }
    }

    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}
