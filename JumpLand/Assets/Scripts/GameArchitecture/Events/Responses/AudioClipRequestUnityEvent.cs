using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class AudioClipRequestUnityEvent : UnityEvent<AudioClipRequest>
	{
	}
}