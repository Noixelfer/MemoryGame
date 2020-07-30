using DG.Tweening;
using System.Collections.Generic;
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

	[SerializeField] private CanvasGroup title;

	private const float INITIAL_DELAY = 1f;
	private const float DELAY_BETWEEN_BUTTONS = 0.3f;

	private List<Button> buttons = new List<Button>();
	private List<Sequence> animationSequences = new List<Sequence>();

	private void Awake()
	{
		startButton?.onClick.AddListener(OnStartPressed);
		highscoreButton?.onClick.AddListener(OnHighscorePressed);
		shopButton?.onClick.AddListener(OnShopPressed);
		settingsButton?.onClick.AddListener(OnSettingsPressed);

		buttons.Add(startButton);
		buttons.Add(highscoreButton);
		buttons.Add(shopButton);
		buttons.Add(settingsButton);

		AnimateTitle();
		AnimateButtons();
	}

	private void OnDestroy()
	{
		startButton?.onClick.RemoveListener(OnStartPressed);
		highscoreButton?.onClick.RemoveListener(OnHighscorePressed);
		shopButton?.onClick.RemoveListener(OnShopPressed);
		settingsButton?.onClick.RemoveListener(OnSettingsPressed);
	}

	private void AnimateTitle()
	{
		title.alpha = 0f;
		title.DOFade(1f, 1.8f).SetEase(Ease.InQuint);
	}

	private void AnimateButtons()
	{
		for (int i = 0; i < 4; i++)
		{
			buttons[i].transform.localScale = Vector3.zero;
			AnimateButton(i, INITIAL_DELAY + DELAY_BETWEEN_BUTTONS * i);
		}
	}

	private void AnimateButton(int index, float delay)
	{
		if (animationSequences.Count >= index)
		{
			animationSequences.Add(DOTween.Sequence());
		}
		else
		{
			if (animationSequences[index].IsPlaying())
			{
				animationSequences[index].Kill(true);
			}
		}

		var seq = animationSequences[index];
		var button = buttons[index];

		seq.Append(button.transform.DOScale(1, 0.1f));
		seq.Append(button.transform.DOPunchScale(Vector3.one * 0.6f, 0.8f, 6, 0.7f).SetEase(Ease.OutCirc));
		seq.PrependInterval(delay);
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
