using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageU
{
    public static Dictionary<Lang, Dictionary<string, string>> LoadTranslate(DataLocalization[] data)
    {
        var tempDic = new Dictionary<Lang, Dictionary<string, string>>();

        for (int i = 0; i < data.Length; i++)
        {
            var tempData = new Dictionary<string, string>();

            foreach (var item in data[i].texts)
            {
                var f = item.text.Split(":");

                foreach (var d in f)
                {
                    var c = d.Split(">");

                        if (c.Length == 2)
                        tempData.Add(c[0].Trim(), c[1].Trim());
                }

            }

            tempDic.Add(data[i].language, tempData);
        }
        return tempDic;
    }
}
