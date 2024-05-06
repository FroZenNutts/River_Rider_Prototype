using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinningManager : MonoBehaviour
{
    int randVal;
    private float timeInterval;
    private bool isCoroutine;
    private int finalAngle;
    private int spinsDone; // New variable to keep track of spins

    public Button spinButton; // Reference to the spin button
    public TextMeshProUGUI winText;
    public TextMeshProUGUI winText2;
    public int section;
    float totalAngle;
    public string[] PrizeName;

    void Start()
    {
        isCoroutine = true;
        totalAngle = 360f / section;
        spinsDone = 0; // Initialize spinsDone to 0
        spinButton.onClick.AddListener(SpinButtonClicked); // Add listener for button click
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && isCoroutine && spinsDone < 2)
        {
            StartCoroutine(Spin());
        }
    }

    void SpinButtonClicked()
    {
        if (isCoroutine && spinsDone < 2)
        {
            StartCoroutine(Spin());
        }
    }

    private IEnumerator Spin()
    {
        isCoroutine = false;
        randVal = Random.Range(20, 30);

        timeInterval = 0.0001f * Time.deltaTime * 2;
        for (int i = 0; i < randVal; i++)
        {
            transform.Rotate(0, 0, totalAngle / 2);

            if (i > Mathf.RoundToInt(randVal * 0.2f))
                timeInterval = 0.5f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.5f))
                timeInterval = 1f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.7f))
                timeInterval = 1.5f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.8f))
                timeInterval = 2f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.9f))
                timeInterval = 2.5f * Time.deltaTime;

            yield return new WaitForSeconds(timeInterval);
        }

        if (Mathf.RoundToInt(transform.eulerAngles.z) % Mathf.RoundToInt(totalAngle) != 0)
            transform.Rotate(0, 0, totalAngle / 2);

        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);

        Debug.Log(finalAngle);

        for (int i = 0; i < section; i++)
        {
            if (finalAngle == i * totalAngle)
            {
                if (spinsDone % 2 == 0) // Check if even or odd spin
                    winText.text = PrizeName[i];
                else
                    winText2.text = PrizeName[i];
            }
        }
        isCoroutine = true;
        spinsDone++; // Increment spinsDone after each spin

        if (spinsDone >= 2) // Disable spin button after two spins
        {
            spinButton.interactable = false;
        }
    }
}



