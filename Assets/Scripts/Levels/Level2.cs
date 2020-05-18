using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level {
    protected override void FillSpawners()
    {
        base.FillSpawners();

        //float screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
        //float screenHalfHeightInWorldUnits = Camera.main.orthographicSize - halfPlayerHeight;

        //shootSpawner.Enqueue(new EnemySpawner
        //{
        //    EnemyPrefab = shooty,
        //    SpawnTime = 2,
        //    position = new Vector2(0, screenHalfHeightInWorldUnits)
        //});

        //currentSpawner = shootSpawner.Dequeue();
    }
}
