
public class ConfigData
{
	public float Frequency { get; }

	public int MaxCount { get; }

	public ConfigData(float frequency, int maxCount)
	{
		Frequency = frequency;
		MaxCount = maxCount;
	}
}