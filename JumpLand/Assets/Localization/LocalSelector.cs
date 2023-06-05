using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalSelector : MonoBehaviour
{
    bool active = false;

    private void Start()
    {
        int ID = PlayerPrefs.GetInt("LOCALE_KEY", 0);
        ChangeLocale(ID);
    }

    public void ChangeLocale(int localeID)
    {
        if (active)
            return;
        StartCoroutine(SetLocale(localeID));
    }
    
    IEnumerator SetLocale(int localeID)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        PlayerPrefs.SetInt("LOCALE_KEY", localeID);
        active = false;
    }
}
