using UnityEngine;
public class CipherHelper {
    // This was meant to replace the text field when you got the incorrect key
    // However there is differences between this and the original encrypted message which breaks the decipher
    // Instead, we now copy from the text field into the 'orignal' variable that way we maintain an intact encrypted message
    // very difficult to figure out what causes the issue.
    public static string ORIGINAL = "ENMI NX GW TIPEQHL!\n\nGWHUQAI TOMF OBGW TA CTNPRTW WA GJMH IQPCEUIS ECETQ.\n\nHUM NSCZMF GBW ABDS, GJI FWFR LQY PQZY EGEABHS, GJEI BVR BPPN BVVVTU IAIH BEWPN MLVAG MC BVVA TIPEQHL NTI FMFRTL TPBV, AHHJTKQBT NPH YCHVTVVC.\n\nTVUXTG...\n\nTOMFLEUGVT GCH YQSZ QB BUKW PWFYL, AWXZSIME XWXZS QF PXZPH, GJIGX KVTY EAPIMF OG HAIRBEF XD JS NBWRS IG ERNP. IG TBPK TA GPRTI BA N PQRRXXH WS ZXVBCEA, XWX JNVDWMHAMR EVNP TTGB RZMHM.\n\nVLT ASYNVUL BVHRVG SU EOABVPK MW CZRUIGOM CMNEI, QBVBVCXTL KNZF.\n\nOAL JEIKMR QF FDKV VV QVSXZ GW RVDMMQG YQZT.\n\nGJIGX OEM PIMNASF, EEJLIZ ZRNEIBWBFPVRW MPOG PCRCHB OM UIETZOGMQ.\n\nW ENPX MW FMIGV MPS NNVI HN GPVU LHZZQ.\n\nT KBZYF DY CATL ZXVBCEA.\n\nI JWENH HN BVYA EXIQR.\n\nT KBZYF DY CATL PDOM.\n\nM PQZY PTIPMM FCPJ P ECETQ.\n\nW IZ... BVR TJSHM CS GJI NKVVPN.\n\nTBZ VVJEG GPVU GXIZVBL... QG I JIAE.\n";
    public static string original = "";
    // Vigènere cipher
    // Each letter of the plaintext is shifted along some number of places with 
    // respect to the alphabet. 
    // If our plaintext is ABC and key is A then the cipher text is ABC.
    // If our plaintext is ABC and key is B then the cipher text is BCD, shifted once.
    // If our plaintext is ABC and key is C then the cipher text is CDE, shifted twice.
    // If our plaintext is ABC and key is CBA then the cipher text is CCC, shifted twice and once for A and B respectively in the plaintext.
    // The decryption is the reverse of the encryption, shifts backwards.

    public static string Decrypt(string ciphertext, string key)
    {
        string decryptedText = "";
        int keyLength = key.Length;
        Debug.Log("keyLength: " + keyLength);
        Debug.Log("ciphertext.Length: " + ciphertext.Length);
        for (int i = 0; i < ciphertext.Length; i++)
        {
            if (!char.IsLetter(ciphertext[i]))
            {
                decryptedText += ciphertext[i];
                continue;
            }
            char cipherChar = ciphertext[i];
            char keyChar = key[i % keyLength];
            int offset = 'A';

            int decryptedChar = ((cipherChar - keyChar + 26) % 26) + offset;
            decryptedText += (char)decryptedChar;
        }

        return decryptedText;
    }
}