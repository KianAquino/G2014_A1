using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Singleton<MainMenu>
{
    [SerializeField] GameObject[] _pages;

    public GameObject[] Pages { get { return _pages; } }

    private void Start()
    {
        Reload();
    }

    /// <summary>
    /// Reloads the UI to it's first page.
    /// </summary>
    public void Reload()
    {
        for (int i = 0; i < _pages.Length; i++)
        {
            if (i == 0) _pages[i].SetActive(true);
            else _pages[i].SetActive(false);
        }
    }

    /// <summary>
    /// Switch to specified page.
    /// </summary>
    /// <param name="pageNumber"></param>
    public void SwitchPage(int pageNumber)
    {
        for (int i = 0; i < _pages.Length; i++)
        {
            if (i == pageNumber) _pages[i].SetActive(true);
            else _pages[i].SetActive(false);
        }
    }
}
