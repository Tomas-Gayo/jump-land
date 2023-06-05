using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "SceneRequest")]
	public sealed class SceneRequestGameEventListener : BaseGameEventListener<SceneRequest, SceneRequestGameEvent, SceneRequestUnityEvent>
	{
	}
}