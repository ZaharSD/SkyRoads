
public class Game : Scene
{
	public static Game Instance;

	private void Awake()
	{
		Instance = this;
	}
}