using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextTranslate : MonoBehaviour
{
    [SerializeField] string _ID;
    TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();

        LocalizationManager.instance.EventTranslate += Translate;

        Translate();
    }

    void Translate()
    {
        _text.text = LocalizationManager.instance.GetTranslate(_ID);
    }

    private void OnDestroy()
    {
        //LocalizationManager.
    }
}
