
public class GameStateManager
{
	public static GameState CurrentGameState { get; private set; }

	public static void SetState(GameState newGameState)
	{
		if (newGameState == CurrentGameState)
			return;

		CurrentGameState = newGameState;
	}
}