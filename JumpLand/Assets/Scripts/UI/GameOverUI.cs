using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TextMeshProUGUI heightResultTxt;

    public void SetResults()
    {
        heightResultTxt.text = string.Empty;
        heightResultTxt.text = PlayerPrefs.GetInt("HEIGHT").ToString();
    }
}
