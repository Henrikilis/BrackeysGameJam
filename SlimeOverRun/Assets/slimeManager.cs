using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class slimeManager : MonoBehaviour
{
    public GameObject gameOverCanvas;

   public void isDead()
    {
        gameOverCanvas.gameObject.SetActive(true);
    }

    public void Reset()
    {
        
    }
}
