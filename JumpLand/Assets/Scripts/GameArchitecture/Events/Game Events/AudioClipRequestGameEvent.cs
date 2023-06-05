using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "AudioClipRequestGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Audio Request",
	    order = 120)]
	public sealed class AudioClipRequestGameEvent : GameEventBase<AudioClipRequest>
	{
	}
}