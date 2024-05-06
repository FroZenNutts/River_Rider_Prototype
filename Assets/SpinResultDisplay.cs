using UnityEngine;
using UnityEngine.UI;

public class SpinResultDisplay : MonoBehaviour
{
    public Image[] resultImages; // Array of UI Images to display the results
    public Sprite[] resultSprites; // Sprites for each possible result

    public string[] resultKeys; // Keys to retrieve the spin results from PlayerPrefs

    void Start()
    {
        for (int i = 0; i < resultKeys.Length; i++)
        {
            // Get the spin result from PlayerPrefs
            string result = PlayerPrefs.GetString(resultKeys[i], "");

            // Display the result as an image
            if (!string.IsNullOrEmpty(result) && i < resultImages.Length)
            {
                resultImages[i].sprite = GetSpriteForResult(result);
            }
        }
    }

    Sprite GetSpriteForResult(string result)
    {
        // Assuming the resultSprites array is arranged such that the index corresponds to the result index
        int index = System.Array.IndexOf(resultSprites, result);
        if (index >= 0 && index < resultSprites.Length)
            return resultSprites[index];
        else
            return null; // Return null if the index is out of range
    }
}
