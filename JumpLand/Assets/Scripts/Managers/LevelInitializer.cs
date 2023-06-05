using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelInitializer : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private SceneSO[] scenes;

    [Header("On Scene Ready")]
    [SerializeField] private UnityEvent onDependenciesLoaded;

    private void Start() => StartCoroutine(LoadDependencies());

    IEnumerator LoadDependencies()
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            SceneSO sceneToLoad = scenes[i];

            if (!SceneManager.GetSceneByName(sceneToLoad.name).isLoaded)
            {
                AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad.sceneName, LoadSceneMode.Additive);

                while(!asyncOperation.isDone)
                    yield return null;
            }
        }

        onDependenciesLoaded!.Invoke();
    }
}
