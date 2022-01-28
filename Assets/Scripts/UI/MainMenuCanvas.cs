using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvas : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _level1Button;
    [SerializeField] private Button _level2Button;
    [SerializeField] private Button _level3Button;
    [SerializeField] private Canvas _lvlChooseCanvas;


    private void Awake()
    {
        _startButton.onClick.AddListener(OnStartButtonClickHandler);
        _exitButton.onClick.AddListener(OnExitButtonClickHandler);
        _level1Button.onClick.AddListener(OnLvl1ButtonClickHandler);
        _level2Button.onClick.AddListener(OnLvl2ButtonClickHandler);
        _level3Button.onClick.AddListener(OnLvl3ButtonClickHandler);
    }

    private void Start()
    {
        _lvlChooseCanvas.enabled = false;
    }

    private void OnStartButtonClickHandler()
    {
        _lvlChooseCanvas.enabled = true;
    }

    private void OnExitButtonClickHandler()
    {
        Application.Quit();
    }

    private void OnLvl1ButtonClickHandler()
    {
        SceneManager.LoadScene("level1");
    }

    private void OnLvl2ButtonClickHandler()
    {
        SceneManager.LoadScene("level2");
    }

    private void OnLvl3ButtonClickHandler()
    {
        SceneManager.LoadScene("level3");
    }




}
