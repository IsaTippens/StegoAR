using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CipherPanel : MonoBehaviour
{

    // Get TextMeshPro component
    public TextMeshProUGUI textMeshPro;

    // Get TextMeshPro TextInput component
    public TMP_InputField textMeshProInput;

    public void DecipherText() {
        // get text from textMeshProInput
        string key = textMeshProInput.text.ToUpper();
        if (key == "") {
            key = "A";
        }
        // get text from textMeshPro
        string text = textMeshPro.text;
        if (CipherHelper.original == "") {
            CipherHelper.original = text;
        }
        // decipher text
        string decipheredText = CipherHelper.Decrypt(text, key);
        // set textMeshPro text to deciphered text
        textMeshPro.text = decipheredText;
    }

    public void ResetText() {
        if (CipherHelper.original == "") {
            return;
        }
        textMeshPro.text = CipherHelper.original;
    }
}
