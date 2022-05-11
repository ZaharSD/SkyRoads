
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SheetChange : View
{
	[SerializeField] private Button _nextImages;

	[SerializeField] private Sprite[] _imagesComics;
	[SerializeField] private Image _panelImages;

	private int _indexCurrentImage;

	public void NextSlide()
	{
		AudioManager.Play("ClickButton");

		if (_indexCurrentImage < _imagesComics.Length)
		{
			StopAllCoroutines();
			Fade();

			_panelImages.sprite = _imagesComics[_indexCurrentImage];

			_indexCurrentImage++;
		}
		else
		{
			PlayerPrefs.SetInt("Comics", 1);

			OpenMainMenu();
		}
	}

	private void Start()
	{
		if (_imagesComics.Length == 0)
		{
			ViewManager.Instance.TriggerClose(this);
			OpenMainMenu();
		}
		else
		{
			_nextImages.onClick.AddListener(NextSlide);

			Fade();

			_panelImages.sprite = _imagesComics[_indexCurrentImage + 1];
		}
	}

	private void OpenMainMenu()
	{
		AudioManager.Play("ClickButton");

		ViewManager.Instance.TriggerClose(this);

		var mainMenu = ViewManager.Instance.MainMenu;
		ViewManager.Instance.TriggerOpen(mainMenu);
	}

	private void Fade()
	{
		var colorImagePanel = _panelImages.color;

		colorImagePanel.a = 0;
		_panelImages.color = colorImagePanel;

		_panelImages.DOKill();
		_panelImages.DOFade(1f, 3f);
	}
}