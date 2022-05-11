
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
	public Menu Menu;
	public Game Game;

	public static GameSceneManager Instance;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);

		TriggerOpen(Menu);
	}

	public static void TriggerClose(Scene view)
	{
		view.Hide();
	}

	public void TriggerOpen(Scene view)
	{
		Instantiate(view, gameObject.transform);
	}
}