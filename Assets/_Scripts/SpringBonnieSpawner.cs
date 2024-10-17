using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBonnieSpawner : Singleton<SpringBonnieSpawner>
{
    [SerializeField] private GameObject _springBonnie;
    [SerializeField] private float _initialDelay;
    private bool _running = false;
    
    public void Begin()
    {
        if (_running == true)
        {
            Debug.Log("FallingObjectsSpawner is already running.");
            return;
        }
        _running = true;

        Invoke("SpawnBonnie", _initialDelay);
    }

    public void Stop() => _running = false;

    private void SpawnBonnie()
    {
        GameObject newBonnie = Instantiate(_springBonnie);
        newBonnie.transform.SetParent(transform);

        float delay = Random.Range(10f, 60f);

        if (_running) Invoke("SpawnBonnie", delay);
    }
}
