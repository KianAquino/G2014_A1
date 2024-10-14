using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    public void OnPlayClicked()
    {
        GameManager.Instance.LoadScene(2);
        AudioSystem.Instance.PlaySFX(SFXType.CLICK);
    }
}
