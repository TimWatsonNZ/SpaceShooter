using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level {

    protected override void FillSpawners()
    {
        base.FillSpawners();

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 0,
            position = new Vector2(-Utility.GetScreenWidth() + 1, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 3,
            position = new Vector2(Utility.GetScreenWidth() - 1, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 5,
            position = new Vector2(-1, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 5,
            position = new Vector2(1, Utility.GetScreenHeight())
        });


        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 7,
            position = new Vector2(0, Utility.GetScreenHeight()),
            behaviour = "Down",
        });


        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 7.5f,
            position = new Vector2(1, Utility.GetScreenHeight()),
            behaviour = "Down",
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 8,
            position = new Vector2(2, Utility.GetScreenHeight()),
            behaviour = "Down",
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 10,
            position = new Vector2(-Utility.GetScreenWidth(), Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 10,
            position = new Vector2(-Utility.GetScreenWidth(), Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 11,
            position = new Vector2(Utility.GetScreenWidth()-1, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 11,
            position = new Vector2(Utility.GetScreenWidth()-1, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 10.5f,
            position = new Vector2(-Utility.GetScreenWidth()+2, Utility.GetScreenHeight()),
            behaviour = "Zigzag",
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 11,
            position = new Vector2(Utility.GetScreenWidth() - 1, Utility.GetScreenHeight()),
            behaviour = "Zigzag",
        });



        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 14,
            position = new Vector2(Utility.GetScreenWidth() - 1, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 14.2f,
            position = new Vector2(Utility.GetScreenWidth() - 2, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 14.4f,
            position = new Vector2(Utility.GetScreenWidth() - 3, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 14.6f,
            position = new Vector2(Utility.GetScreenWidth() - 4, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 14.8f,
            position = new Vector2(Utility.GetScreenWidth() - 5, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 15f,
            position = new Vector2(Utility.GetScreenWidth() - 6, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 20,
            position = new Vector2(- 2, Utility.GetScreenHeight()),
            behaviour = "Zigzag",
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 20,
            position = new Vector2(0, Utility.GetScreenHeight()),
            behaviour = "Zigzag",
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 20,
            position = new Vector2(2, Utility.GetScreenHeight()),
            behaviour = "Zigzag",
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 24,
            position = new Vector2(-2, Utility.GetScreenHeight()),
            behaviour = "Zigzag",
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 24,
            position = new Vector2(0, Utility.GetScreenHeight()),
            behaviour = "Zigzag",
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 24,
            position = new Vector2(2, Utility.GetScreenHeight()),
            behaviour = "Zigzag",
        });
        
        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 25,
            position = new Vector2(-Utility.GetScreenWidth(), Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 25,
            position = new Vector2(-Utility.GetScreenWidth()+1, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 25,
            position = new Vector2(Utility.GetScreenWidth(), Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 25,
            position = new Vector2(Utility.GetScreenWidth()-1, Utility.GetScreenHeight())
        });



        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 28,
            position = new Vector2(-2, Utility.GetScreenHeight()),
            behaviour = "Down",
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 28,
            position = new Vector2(-1, Utility.GetScreenHeight()),
            behaviour = "Down",
        });
        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 28,
            position = new Vector2(1, Utility.GetScreenHeight()),
            behaviour = "Down",
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = shooty,
            SpawnTime = 30,
            position = new Vector2(2, Utility.GetScreenHeight()),
            behaviour = "Down",
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 30,
            position = new Vector2(1, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 32,
            position = new Vector2(-Utility.GetScreenWidth(), Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 32,
            position = new Vector2(-Utility.GetScreenWidth(), Utility.GetScreenHeight()-1)
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 32,
            position = new Vector2(-Utility.GetScreenWidth(), Utility.GetScreenHeight()-2)
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 32,
            position = new Vector2(-Utility.GetScreenWidth(), Utility.GetScreenHeight()-3)
        });


        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = hunter,
            SpawnTime = 34,
            position = new Vector2(-Utility.GetScreenWidth()+2, Utility.GetScreenHeight() - 3)
        });
        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = hunter,
            SpawnTime = 34,
            position = new Vector2(Utility.GetScreenWidth() - 2, Utility.GetScreenHeight() - 3)
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 36,
            position = new Vector2(-Utility.GetScreenWidth()+1, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 37,
            position = new Vector2(-Utility.GetScreenWidth()+2, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 38,
            position = new Vector2(-Utility.GetScreenWidth()+3, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 39,
            position = new Vector2(-Utility.GetScreenWidth()+4, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 40,
            position = new Vector2(-Utility.GetScreenWidth()+5, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 41,
            position = new Vector2(-Utility.GetScreenWidth()+6, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 42,
            position = new Vector2(-Utility.GetScreenWidth()+7, Utility.GetScreenHeight())
        });

        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = blobby,
            SpawnTime = 43,
            position = new Vector2(-Utility.GetScreenWidth()+8, Utility.GetScreenHeight())
        });


        spawnManager.spawners.Add(new EnemySpawner
        {
            EnemyPrefab = boss,
            SpawnTime = 50,
            position = new Vector2(0, Utility.GetScreenHeight())
        });

    }
}
