using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private LoadingScreenUI loadingScreen;

    // Private References
    SceneRequest pendingRequest;

    public void LoadSceneMenuRequest(SceneRequest request)
    {
        if (!IsSceneAlreadyLoaded(request.scene))
            SceneManager.LoadScene(request.scene.sceneName);
    }

    public void LoadSceneLevelRequest(SceneRequest request)
    {
        if (!IsSceneAlreadyLoaded(request.scene))
        {
            if (request.toggleScreen)
                RequestToggleScreen(request);
            else
                StartCoroutine(ProcessLevelScreen(request));
        }
        else
        {
            ActivateScene(request);
        }
    }

    public void ResetLevelRequest(SceneRequest request)
    {
        if (request.toggleScreen)
            RequestToggleScreen(request);
        else
            StartCoroutine(ProcessLevelScreen(request));
    }

    public void OnLoadingScreenToggled(bool enabled)
    {
        if (enabled && pendingRequest != null)
            StartCoroutine(ProcessLevelScreen(pendingRequest));

    }
    void RequestToggleScreen(SceneRequest request)
    {
        pendingRequest = request;
        loadingScreen.ToggleScreen(true);
    }

    IEnumerator ProcessLevelScreen(SceneRequest request)
    {
        if (request.scene != null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.UnloadSceneAsync(currentScene);

            AsyncOperation loadSceneProcess = SceneManager.LoadSceneAsync(request.scene.sceneName, mode: LoadSceneMode.Additive);

            while (!loadSceneProcess.isDone)
                yield return null;

            ActivateScene(request); 
        }
    }

    void ActivateScene(SceneRequest request)
    {
        Scene sceneToActivate = SceneManager.GetSceneByName(request.scene.sceneName);
        SceneManager.SetActiveScene(sceneToActivate);

        if (request.toggleScreen) loadingScreen.ToggleScreen(false);

        pendingRequest = null;
    }

    bool IsSceneAlreadyLoaded(SceneSO scene)
    {
        Scene sceneToLoad = SceneManager.GetSceneByName(scene.sceneName);
        
        if (sceneToLoad != null && sceneToLoad.isLoaded)
            return true;
        else
            return false;
    }
}
