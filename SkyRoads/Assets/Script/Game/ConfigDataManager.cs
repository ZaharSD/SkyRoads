
using System.Collections.Generic;

public class ConfigDataManager
{
	public static Stack<ConfigData> ConfigData { get; } = new Stack<ConfigData>();

	private static void FillStack()
	{
		ConfigData.Push(new ConfigData(80, 700));
		ConfigData.Push(new ConfigData(50, 350));
		ConfigData.Push(new ConfigData(40, 220));
		ConfigData.Push(new ConfigData(20, 120));
		ConfigData.Push(new ConfigData(10, 40));
		ConfigData.Push(new ConfigData(0, 0));
	}

	public static void ResetDifficulty()
	{
		ConfigData.Clear();

		FillStack();

		GameManager.Instance.PassedTiles = 0;

		AsteroidManager.OccurrenceFrequencyAsteroid = 0;
	}
}