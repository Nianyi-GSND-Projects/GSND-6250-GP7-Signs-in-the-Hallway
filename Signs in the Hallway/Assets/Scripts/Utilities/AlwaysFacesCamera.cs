using UnityEngine;

namespace Game
{
	public class AlwaysFacesCamera : MonoBehaviour
	{
		void LateUpdate()
		{
			transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
		}
	}
}
