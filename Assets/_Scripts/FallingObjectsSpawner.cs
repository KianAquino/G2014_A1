using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FallingObjectsSpawner : Singleton<FallingObjectsSpawner>
{
    private bool _running = false;
    private float _delay;
    private float _speed;

    private void Start()
    {
        _delay = LevelManager.Instance.BaseSpawnInterval;
        _speed = LevelManager.Instance.Gravity;
    }

    public void Begin()
    {
        if (_running == true)
        {
            Debug.Log("FallingObjectsSpawner is already running.");
            return;
        }
        _running = true;

        SpawnObjects();
    }

    public void Stop() => _running = false;

    private void SpawnObjects()
    {
        GameObject prefab = LevelManager.Instance.FallingObject;

        GameObject newObject = Instantiate(prefab);
        newObject.transform.SetParent(transform);
        newObject.transform.position = LevelManager.Instance.GetRandomSpawnPosition();

        FallingObject fallingObject = newObject.GetComponent<FallingObject>();
        fallingObject.SetSpeed(_speed);

        _delay -= 0.02f;
        _delay = Mathf.Max(_delay, 1f);
        _speed += 0.0125f;
        _speed = Mathf.Min(_speed, 2.5f);

        if (_running) Invoke("SpawnObjects", _delay);
    }
}
