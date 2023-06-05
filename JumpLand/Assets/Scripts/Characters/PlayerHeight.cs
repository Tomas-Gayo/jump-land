using UnityEngine;
using ScriptableObjectArchitecture;

public class PlayerHeight : MonoBehaviour
{
    [Tooltip("The start point of the game where the player is spawn.")]
    [SerializeField] private Transform origin;

    [Header("Broadcasting On")]
    [SerializeField] private FloatGameEvent heightEvent;

    [HideInInspector] public float height;
    [HideInInspector] public float recordHeight = 0;

    private void Update() => HeightCalculation();

    public void HeightCalculation()
    {
        height = (transform.position - origin.position).magnitude;
        if (height > recordHeight)
        {
            recordHeight = height;
            heightEvent!.Raise(height);
        }
    }

    public void SaveHeight() 
    {
        int heightResult = (int)recordHeight;
        PlayerPrefs.SetInt("HEIGHT", heightResult);
    }
}
