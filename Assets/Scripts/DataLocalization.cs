
using UnityEngine;

[System.Serializable]
public struct DataLocalization
{
    public Lang language;
    public TextAsset[] texts;
}

public enum Lang
{
    ENG,
    SPA,
    FRA,
    GER
}