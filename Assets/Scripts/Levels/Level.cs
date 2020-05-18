using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner
{
    public Enemy EnemyPrefab;
    public float SpawnTime;
    public Vector2 position;
    public bool spawned = false;
    public string behaviour;
}

enum LevelState
{
    None,
    Starting,
    Running,
    Ending,
}

public class SpawnManager
{
    public List<EnemySpawner> spawners;
    public int EnemyCount = 0;

    public SpawnManager()
    {
        spawners = new List<EnemySpawner>();
    }

    public bool FinishedSpawning()
    {
        return spawners.Count == 0;
    }

    void OnChildDeath()
    {
        EnemyCount--;
    }

    public void Update(Transform parent)
    {
        foreach(EnemySpawner currentSpawner in spawners)
        {
            if (currentSpawner.spawned == false && Time.time > currentSpawner.SpawnTime)
            {
                var child = Blobby.Instantiate(currentSpawner.EnemyPrefab, currentSpawner.position, Quaternion.identity);
                child.transform.parent = parent;
                EnemyCount++;
                child.OnDeath += OnChildDeath;
                child.behaviour = currentSpawner.behaviour;
                currentSpawner.spawned = true;
            }
        }
        spawners.RemoveAll(spawner => spawner.spawned);
    }
}

public class Level : MonoBehaviour {

    public Shooty shooty;
    public Blobby blobby;
    public Hunter hunter;
    public Boss boss;
    public string LevelName;
    public LevelStart levelStartPrefab;
    public LevelEnd levelEndPrefab;
    public System.Action OnLevelEnd;
    public Transform background;
    public float levelDuration = 100;
    
    LevelStart levelStartInstance;
    LevelEnd levelEndInstance;
    protected float nextSpawn;

    protected SpawnManager spawnManager;

    LevelState state = LevelState.None;

    void Start()
    {
        spawnManager = new SpawnManager();
        state = LevelState.Starting;
        levelStartInstance = Instantiate(levelStartPrefab, transform);
        levelStartInstance.OnAnimationEnded += OnLevelStartEnd;
        levelStartInstance.level = this;
    }

    protected virtual void FillSpawners()
    {

    }

    void OnLevelStartEnd()
    {
        Destroy(levelStartInstance);
        FillSpawners();
        this.state = LevelState.Running;
    }

    void EndLevel()
    {
        state = LevelState.Ending;
        levelEndInstance = Instantiate(levelEndPrefab, transform);
        levelEndInstance.OnAnimationEnded += OnLevelEndEnd;
        levelEndInstance.level = this;
    }

    void OnLevelEndEnd()
    {
        Destroy(levelEndInstance);
        OnLevelEnd();
    }

    // Update is called once per frame
    public void Update () {
        
        if (state == LevelState.Running)
        {
            float yMovePerSecond = Camera.main.orthographicSize / levelDuration;
            background.position = new Vector3(background.position.x, background.position.y - (yMovePerSecond * Time.deltaTime), background.position.z);
            spawnManager.Update(transform);
            if (spawnManager.FinishedSpawning() && spawnManager.EnemyCount == 0)
            {
                EndLevel();
            }
        }
	}
}
