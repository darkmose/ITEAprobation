using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameCanvas : MonoBehaviour
{
    private const int MainMenuSceneIndex = 0;
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _toMainMenuButton;
    private Contexts _contexts;

    private void Awake()
    {
        _toMainMenuButton.onClick.AddListener(ToMainMenuButtonClickHandler);
        _retryButton.onClick.AddListener(RetryButtonClickHandler);
        _contexts = Contexts.sharedInstance;
    }

    private void RetryButtonClickHandler()
    {
        var retryEntity = _contexts.input.CreateEntity();
        retryEntity.AddRetryButton(SceneManager.GetActiveScene());
    }

    private void ToMainMenuButtonClickHandler()
    {
        var mainMenuEntity = _contexts.input.CreateEntity();
        mainMenuEntity.AddMainMenuButton(SceneManager.GetSceneAt(MainMenuSceneIndex));
    }
}
