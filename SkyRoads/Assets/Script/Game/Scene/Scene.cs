
using UnityEngine;

public class Scene : MonoBehaviour
{
	public virtual void Hide()
	{
		Destroy(gameObject);
	}
}