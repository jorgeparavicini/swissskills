﻿using System;
using System.Collections;
using EventArgs;
using Level;
using Score;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VR;

namespace UI
{
    public class GameStatusUi : MonoBehaviour
    {
        public GameObject GameOverContent;
        public GameObject GameStartContent;
        public GameObject GameStartButton;
        public TextMeshProUGUI GameStartDelayText;
        public TextMeshProUGUI GameOverScoreText;
        public LaserPointerVrButtonHandler HandLaserPointer;

        private void OnEnable()
        {
            LevelManager.GameOver += OnGameOver;
            LevelManager.GameStarting += OnGameStarting;
            LevelManager.GameStarted += OnGameStarted;
            LevelManager.GameStarterTimeUpdated += OnGameStarterTimeUpdated;
        }

        private void OnDisable()
        {
            LevelManager.GameOver -= OnGameOver;
            LevelManager.GameStarting -= OnGameStarting;
            LevelManager.GameStarted -= OnGameStarted;
            LevelManager.GameStarterTimeUpdated -= OnGameStarterTimeUpdated;
        }

        private void OnGameStarterTimeUpdated(object sender, TimeUpdatedEventArgs e)
        {
            GameStartDelayText.text = $"{e.Time:0}";
        }

        private void OnGameStarted(object sender, System.EventArgs e)
        {
            GameStartContent.SetActive(false);
        }

        private void OnGameStarting(object sender, System.EventArgs e)
        {
            HandLaserPointer.DisablePointer();
            GameStartButton.SetActive(false);
            GameStartDelayText.gameObject.SetActive(true);
        }

        private void OnGameOver(object sender, System.EventArgs e)
        {
            GameOverContent.SetActive(true);
            GameOverScoreText.text = $"Your Score: {ScoreManager.Score}";
        }

        public void StartGame_Button()
        {
            LevelManager.StartGame();
        }
    }
}
