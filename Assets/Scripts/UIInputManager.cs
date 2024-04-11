using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    public string[] UINavigationKeys;
    [HideInInspector] public KeyCode[] buttonKeys;

    private void Awake()
    {
        buttonKeys = KeyConverter(UINavigationKeys);
    }

    private KeyCode[] KeyConverter(string[] stringArray)
    {
        KeyCode[] keys = new KeyCode[stringArray.Length];
        for (int i = 0; i < stringArray.Length; i++)
        {
            if (string.IsNullOrEmpty(stringArray[i])) { DebugArray(stringArray, i); return null; }

            int intFromString = -1;
            string stringFromInt = string.Empty;

            string keyString = string.Empty;
            if (Int32.TryParse(stringArray[i], out intFromString)) stringFromInt = "Alpha" + intFromString.ToString();

            if (string.IsNullOrEmpty(stringFromInt))
            {
                char[] key = stringArray[i].ToCharArray();
                keyString = char.ToUpper(key[0]).ToString();
            }
            else keyString = stringFromInt;

            keys[i] = (KeyCode)Enum.Parse(typeof(KeyCode), keyString);
        }
        return keys;
    }

    private void DebugArray(string[] array, int index)
    {
        Debug.LogError("Missing inputs at index " + index + " of an array");
    }
}
