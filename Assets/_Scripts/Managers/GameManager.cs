using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        // Load Main Menu
        LoadScene(1);
    }

    /// <summary>
    /// Reloads core scene to get to the main menu. Clears out all other scenes.
    /// </summary>
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Load
    /// </summary>
    /// <param name="buildIndex"></param>
    /// <returns></returns>
    public bool LoadScene(int buildIndex, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
    {
        int sceneCount = SceneManager.sceneCount;
        List<Scene> unloadScenes = new List<Scene>();

        // Create list of scenes to unload
        for (int i = 0; i < sceneCount; i++)
        {
            if (loadSceneMode == LoadSceneMode.Additive) break;

            Scene scene = SceneManager.GetSceneAt(i);

            // Skip core scene
            if (scene == SceneManager.GetSceneByBuildIndex(0)) continue;

            // If desired scene is already loaded
            if (scene == SceneManager.GetSceneByBuildIndex(buildIndex))
            {
                unloadScenes.Clear();
                Debug.LogError($"Attemted to load a scene that's already loaded. ({scene.name})");
                return false;
            }

            unloadScenes.Add(scene);
        }

        //Unload scenes
        foreach (Scene scene in unloadScenes)
        {
            SceneManager.UnloadSceneAsync(scene);
        }

        SceneManager.LoadScene(buildIndex, LoadSceneMode.Additive);

        unloadScenes.Clear();

        return true;
    }
}
