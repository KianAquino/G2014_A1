using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    public void OnPlayClicked()
    {
        GameManager.Instance.LoadScene(2);
        ClickSound();
    }

    public void OnInstructionsClicked()
    {
        MainMenu.Instance.SwitchPage(1);
        ClickSound();
    }

    public void OnReturnClicked()
    {
        MainMenu.Instance.Reload();
        ClickSound();
    }

    private void ClickSound() => AudioSystem.Instance.PlaySFX(SFXType.CLICK, 0.5f);
}
