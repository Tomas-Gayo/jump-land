using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class AudioClipRequestReference : BaseReference<AudioClipRequest, AudioClipRequestVariable>
	{
	    public AudioClipRequestReference() : base() { }
	    public AudioClipRequestReference(AudioClipRequest value) : base(value) { }
	}
}