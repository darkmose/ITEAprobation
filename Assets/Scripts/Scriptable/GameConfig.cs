using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/Game Config")]
public class GameConfig : ScriptableObject
{
    public int peopleInRow = 20;
    public float groupRadiusStep = 0.4f;
    public float fightGroupRadius = 0.2f;
    public GameObject peopleCountCanvasPrefab;
    public GameObject endGameCanvas;
    [Range(0f,3f)]
    public float playerSpeed = 1;
    [Range(0f,3f)]
    public float enemiesSpeed = 1;
    [Range(0f,1f)]
    public float playerHorizSpeed;
    [Range(0f,1f)]
    public float enemyHorizSpeed;
}
