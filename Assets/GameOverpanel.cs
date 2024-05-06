using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverpanel : MonoBehaviour
{
  
    public GameObject gameOverPanel;


    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

  
    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }
}

