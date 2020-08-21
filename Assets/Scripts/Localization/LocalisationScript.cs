using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LocalisationScript
{
    public enum Language
    {
        English,
        French,
        Spanish,
        Japanese,
        Korean,
        Chinese,
        Russian,
        German,
        Italian
    }

    public static Language language = Language.English;

    private static Dictionary<string, string> localisedEN;
    private static Dictionary<string, string> localisedFR;
    private static Dictionary<string, string> localisedES;
    private static Dictionary<string, string> localisedRU;
    private static Dictionary<string, string> localisedJA;
    private static Dictionary<string, string> localisedKO;
    private static Dictionary<string, string> localisedZH;
    private static Dictionary<string, string> localisedIT;
    private static Dictionary<string, string> localisedDE;

    public static bool isInit;

    public static void Init()
    {

        if (Enum.IsDefined(typeof(Language), (Language)Enum.Parse(typeof(Language), Application.systemLanguage.ToString())))
        {
            language = (Language)Enum.Parse(typeof(Language), Application.systemLanguage.ToString());
        }
        else
        {
            language = Language.English;
        }

        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localisedEN = csvLoader.GetDictionaryValues("en");
        localisedFR = csvLoader.GetDictionaryValues("fr");
        localisedES = csvLoader.GetDictionaryValues("es");
        localisedRU = csvLoader.GetDictionaryValues("ru");
        localisedJA = csvLoader.GetDictionaryValues("ja");
        localisedKO = csvLoader.GetDictionaryValues("ko");
        localisedZH = csvLoader.GetDictionaryValues("zh");
        localisedIT = csvLoader.GetDictionaryValues("it");
        localisedDE = csvLoader.GetDictionaryValues("de");

        isInit = true;
    }

    public static string GetLocalisedValue(string key)
    {
        if (!isInit)
        {
            Init();
        }

        string value = key;

        switch (language)
        {
            case Language.English:
                localisedEN.TryGetValue(key, out value);
                break;
            case Language.French:
                localisedFR.TryGetValue(key, out value);
                break;
            case Language.Spanish:
                localisedES.TryGetValue(key, out value);
                break;
            case Language.Russian:
                localisedRU.TryGetValue(key, out value);
                break;
            case Language.Japanese:
                localisedJA.TryGetValue(key, out value);
                break;
            case Language.Korean:
                localisedKO.TryGetValue(key, out value);
                break;
            case Language.Chinese:
                localisedZH.TryGetValue(key, out value);
                break;
            case Language.Italian:
                localisedIT.TryGetValue(key, out value);
                break;
            case Language.German:
                localisedDE.TryGetValue(key, out value);
                break;
        }
        return value;
    }
}
