using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizeTextMesh : MonoBehaviour
{
    TextMeshProUGUI textfield;

    public string localisationKey;

    void Start()
    {
        textfield = GetComponent<TextMeshProUGUI>();
        updateLocalization();
    }

    public void updateLocalization()
    {
        string value = LocalisationScript.GetLocalisedValue(localisationKey);
        if (value != null && textfield != null)
        {
            textfield.text = value;
        }
    }
}
