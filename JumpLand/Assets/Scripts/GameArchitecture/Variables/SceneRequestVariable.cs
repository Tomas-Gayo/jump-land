using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class SceneRequestEvent : UnityEvent<SceneRequest> { }

	[CreateAssetMenu(
	    fileName = "SceneRequestVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "SceneRquestEvent",
	    order = 120)]
	public class SceneRequestVariable : BaseVariable<SceneRequest, SceneRequestEvent>
	{
	}
}