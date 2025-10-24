using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager instance;

    public Lang language;

    public DataLocalization[] data;

    Dictionary<Lang, Dictionary<string, string>> _translate = new();

    public event Action EventTranslate;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            _translate = LanguageU.LoadTranslate(data);
            DontDestroyOnLoad(this);
        }
        else Destroy(this);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1)) ChangeLang(Lang.ENG);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeLang(Lang.SPA);
    }

    public void ChangeLang(Lang newLang)
    {
        if (language == newLang) return;

        language = newLang;
        EventTranslate?.Invoke();
    }

    public string GetTranslate(string id)
    {
        if (!_translate.ContainsKey(language))
            return "No lang";

        if (!_translate[language].ContainsKey(id))
            return "no ID";

        return _translate[language][id]; 
    }
}
