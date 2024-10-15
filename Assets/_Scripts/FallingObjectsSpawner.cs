using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FallingObjectsSpawner : Singleton<FallingObjectsSpawner>
{
    private bool _running = false;
    public void Begin()
    {
        _running = true;

        SpawnObjects();
    }

    public void Stop() => _running = false;

    private void SpawnObjects()
    {
        if (!_running) return;

        GameObject prefab = LevelManager.Instance.FallingObject;

        GameObject newObject = Instantiate(prefab);
        newObject.transform.SetParent(transform);
        newObject.transform.position = LevelManager.Instance.GetRandomSpawnPosition();

        Invoke("SpawnObjects", LevelManager.Instance.BaseSpawnInterval);
    }
}
