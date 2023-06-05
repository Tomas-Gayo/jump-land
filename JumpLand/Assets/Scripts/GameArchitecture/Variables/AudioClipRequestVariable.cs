using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class AudioClipRequestEvent : UnityEvent<AudioClipRequest> { }

	[CreateAssetMenu(
	    fileName = "AudioClipRequestVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Audio Request",
	    order = 120)]
	public class AudioClipRequestVariable : BaseVariable<AudioClipRequest, AudioClipRequestEvent>
	{
	}
}