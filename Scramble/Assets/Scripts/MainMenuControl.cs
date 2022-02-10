using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu = default;
    [SerializeField] private GameObject _howToPlay = default;
#if UNITY_WEBGL
    [SerializeField] private GameObject _exitButton = default;
#endif

    public void OnPlayClicked()
    {
        Debug.Log("Play clicked");
    }

    public void OnHowToPlayClicked()
    {
        _mainMenu.SetActive(false);
        _howToPlay.SetActive(true);
    }

    public void OnExitClicked()
    {
        Application.Quit();
        Debug.Log("Exit clicked");
    }

    public void OnCloseHowToPlayClicked()
    {
        _mainMenu.SetActive(true);
        _howToPlay.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_WEBGL
        _exitButton.SetActive(false);
#endif
    }
}
