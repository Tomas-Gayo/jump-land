using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "SceneRequestGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "SceneRquestEvent",
	    order = 120)]
	public sealed class SceneRequestGameEvent : GameEventBase<SceneRequest>
	{
	}
}