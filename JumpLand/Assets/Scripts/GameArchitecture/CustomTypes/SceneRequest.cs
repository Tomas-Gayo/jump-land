public class SceneRequest
{
    public SceneSO scene;
    public bool toggleScreen;

    public SceneRequest(SceneSO scene, bool toggleScreen)
    {
        this.scene = scene;
        this.toggleScreen = toggleScreen;
    }
}
