using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : BaseBehaviour
{
	[SerializeField] private Button startButton;
	[SerializeField] private Button highscoreButton;
	[SerializeField] private Button shopButton;
	[SerializeField] private Button settingsButton;

	[SerializeField] private Transform startContainer;
	[SerializeField] private Transform highscoreContainer;
	[SerializeField] private Transform shopContainer;
	[SerializeField] private Transform settingsContainer;

	private void Awake()
	{
		startButton?.onClick.AddListener(OnStartPressed);
		highscoreButton?.onClick.AddListener(OnHighscorePressed);
		shopButton?.onClick.AddListener(OnShopPressed);
		settingsButton?.onClick.AddListener(OnSettingsPressed);

		AnimateButtons();
	}

	private void OnDestroy()
	{
		startButton?.onClick.RemoveListener(OnStartPressed);
		highscoreButton?.onClick.RemoveListener(OnHighscorePressed);
		shopButton?.onClick.RemoveListener(OnShopPressed);
		settingsButton?.onClick.RemoveListener(OnSettingsPressed);
	}

	private void AnimateButtons()
	{
		startButton.transform.localScale = Vector3.zero;
		highscoreButton.transform.localScale = Vector3.zero;
		shopButton.transform.localScale = Vector3.zero;
		settingsButton.transform.localScale = Vector3.zero;

		Invoke(() => startButton.transform.DOScale(1, 0.3f), 0.1f);
		Invoke(() => highscoreButton.transform.DOScale(1, 0.3f), 0.3f);
		Invoke(() => shopButton.transform.DOScale(1, 0.3f), 0.5f);
		Invoke(() => settingsButton.transform.DOScale(1, 0.3f), 0.7f);
	}

	private void OnSettingsPressed()
	{
	}

	private void OnShopPressed()
	{
	}

	private void OnHighscorePressed()
	{
	}

	private void OnStartPressed()
	{
	}
}
