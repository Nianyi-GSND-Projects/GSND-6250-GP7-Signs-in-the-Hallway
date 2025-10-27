using UnityEngine;
using System.Collections;
using NaniCore;

namespace Game
{
	public class GameInstance : MonoBehaviour
	{
		[SerializeField] Player player;
		[SerializeField] CanvasGroup focusDot;
		[SerializeField] CanvasGroup blackScreen;
		[SerializeField][Min(0)] float blackScreenTime;

		public bool PlayerControlEnabled
		{
			get => player.isActiveAndEnabled;
			set
			{
				player.gameObject.SetActive(value);
				focusDot.gameObject.SetActive(value);
			}
		}

		public bool BlackScreenOn
		{
			get => blackScreen.isActiveAndEnabled;
			set
			{
				StopCoroutine(nameof(SetBlackScreen));
				StartCoroutine(nameof(SetBlackScreen), value);
			}
		}

		float BlackScreenAlpha
		{
			get => blackScreen.alpha;
			set
			{
				value = Mathf.Clamp01(value);
				blackScreen.alpha = value;
				blackScreen.gameObject.SetActive(value > 0);
			}
		}

		IEnumerator SetBlackScreen(bool value)
		{
			foreach(var t in MathUtility.Tween(blackScreenTime))
			{
				BlackScreenAlpha = value ? t : 1 - t;
				yield return new WaitForEndOfFrame();
			}
		}

		protected void Start()
		{
			BlackScreenAlpha = 1;
			BlackScreenOn = false;
		}

		public void Die()
		{
			Debug.Log("Die");
		}

		public void Escape()
		{
			Debug.Log("Escape");
		}
	}
}
