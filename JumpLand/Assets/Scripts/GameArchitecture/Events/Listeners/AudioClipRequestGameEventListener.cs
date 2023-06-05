using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "AudioClipRequest")]
	public sealed class AudioClipRequestGameEventListener : BaseGameEventListener<AudioClipRequest, AudioClipRequestGameEvent, AudioClipRequestUnityEvent>
	{
	}
}