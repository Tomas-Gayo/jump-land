using UnityEngine;
using ScriptableObjectArchitecture;

public class LoadScene : MonoBehaviour
{
    [Header("Request")]
    [SerializeField] private SceneSO sceneToLoad;
    [SerializeField] private bool loadingScreen;

    [Header("Broadcasting On")]
    [SerializeField] private SceneRequestGameEvent loadSceneEvent;

    public void LoadSceneRequest()
    {
        var request = new SceneRequest(
            scene: sceneToLoad,
            toggleScreen: loadingScreen
        );

        loadSceneEvent!.Raise(request);
    }
}
