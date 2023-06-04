using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _spawnTime;
    public float SpawnTime => _spawnTime;
    void Start()
    {       
        InvokeRepeating("Spawn",0, SpawnTime);
    }

    void Spawn()
    {
        float spawnMargin = 1f;
        Camera mainCamera = Camera.main;
        Vector2 screenBottomLeft = mainCamera.ScreenToWorldPoint(Vector3.zero);
        Vector2 screenTopRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        float x = Random.Range(screenBottomLeft.x - spawnMargin, screenTopRight.x + spawnMargin);
        float y = Random.Range(screenBottomLeft.y - spawnMargin, screenTopRight.y + spawnMargin);

        Vector2 spawnPosition = new Vector2(x, y);
        Vector2 viewportPosition = mainCamera.WorldToViewportPoint(spawnPosition);

        while (viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1)
        {
            x = Random.Range(screenBottomLeft.x - spawnMargin, screenTopRight.x + spawnMargin);
            y = Random.Range(screenBottomLeft.y - spawnMargin, screenTopRight.y + spawnMargin);
            spawnPosition = new Vector2(x, y);
            viewportPosition = mainCamera.WorldToViewportPoint(spawnPosition);
        }

        Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);


    }


}



