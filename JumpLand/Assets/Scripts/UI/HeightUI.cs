using UnityEngine;
using TMPro;

public class HeightUI : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TextMeshProUGUI heightTxt;

    public void DisplayUI(int height)
    {
        heightTxt.text = height.ToString();
    }
}
