using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class slimeManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public SlimeMovement[] sm;
    public winCondition wc;

    [SerializeField]
    private float currentSlimes;
    [SerializeField]
    private int timer;
    [SerializeField]
    private bool isActive;

   

    public void Start()
    {
        timer = 1;
        wc = FindObjectOfType<winCondition>();
        sm = FindObjectsOfType<SlimeMovement>();
        isActive = false;
   
    }

    public void Update()
    {

        if(!isActive)
            StartCoroutine(slimeCount());

        if (isActive)
        {

            currentSlimes = 0;
            sm = FindObjectsOfType<SlimeMovement>();

            for (int i = 0; i < sm.Length; i++)
            {

                currentSlimes++;
            }
            if (currentSlimes <= wc.slimeToWin)
            {
                gameOverCanvas.gameObject.SetActive(true);

            }
        }


    }

    public void isDead()
    {
        gameOverCanvas.gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator slimeCount()
    {
        
        yield return new WaitForSeconds(timer);
  
        isActive = true;

        yield return new WaitForSeconds(timer);

        isActive = false;



    }

}
