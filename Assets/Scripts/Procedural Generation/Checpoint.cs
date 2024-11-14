using System;
using UnityEngine;

public class Checpoint : MonoBehaviour
{
    [SerializeField] float checkPointTimeExtension = 5f;
    [SerializeField] float obstacleDecreaseTimeAmount = .2f;
    const string playerString = "Player";
    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;

    void Start(){
        gameManager = FindFirstObjectByType<GameManager>();   
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag(playerString)){
            gameManager.IncreaseTime(checkPointTimeExtension);
            obstacleSpawner.DecreaseObstacleSpawnTime(obstacleDecreaseTimeAmount);
        }
    }
}
