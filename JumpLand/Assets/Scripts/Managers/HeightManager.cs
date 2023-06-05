using UnityEngine;

public class HeightManager : MonoBehaviour
{
    [Header("Dependencies")]
    public HeightUI heightUI;    


    public void SetUpHealthUI(float height) => heightUI.DisplayUI((int)height);
}
