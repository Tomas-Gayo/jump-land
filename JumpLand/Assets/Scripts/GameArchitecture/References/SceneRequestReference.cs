using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class SceneRequestReference : BaseReference<SceneRequest, SceneRequestVariable>
	{
	    public SceneRequestReference() : base() { }
	    public SceneRequestReference(SceneRequest value) : base(value) { }
	}
}