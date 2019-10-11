using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class App_Initialize : MonoBehaviour ,IUnityAdsListener
{

    public GameObject inMenuUI;
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public GameObject adButton;
    public GameObject restartButton;
    public GameObject player;
    private bool hasGameStarted = false;
    private bool hasSeenAd = false;
    public GameObject soundButton;

    private string gameId = "1486550";

    private void Awake(){
        Shader.SetGlobalFloat("_Curvature", 2.0f);
        Shader.SetGlobalFloat("_Trimming", 0.1f);
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start(){
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        inMenuUI.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
        
    }

    public void PauseAudio()
    {
        if (!AudioListener.pause)
        {
            AudioListener.pause = true;
            soundButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            AudioListener.pause = false;
            soundButton.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        }
    }

    public void PlayButton()
    {
        if (hasGameStarted)
        {
            StartCoroutine(StartGame(1.0f));
        }
        else
        {
            StartCoroutine(StartGame(0.0f));
        }
        
    }

    public void PauseGame()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        inMenuUI.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
        hasGameStarted = true;
    }

    public void GameOver()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        inMenuUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
        if (hasSeenAd)
        {
            adButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            adButton.GetComponent<Button>().enabled = false;
            adButton.GetComponent<Animator>().enabled = false;
            restartButton.GetComponent<Animator>().enabled = true;
        }
        
    }

    public void RestartGame()
    {
    
        SceneManager.LoadScene(0);
    }
    
    
    public void ShowAdd()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
 

    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                hasSeenAd = true;
                StartCoroutine(StartGame(1.5f));
                break;
            case ShowResult.Skipped:

                break;

            case ShowResult.Failed:

                break;

        }
    }
   

    IEnumerator StartGame(float waitTime){
        
        inMenuUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(true);
        gameOverUI.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitTime);

        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;


    }
    
    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == "rewardedVideo")
        {
            Advertisement.Show("rewardedVideo");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                hasSeenAd = true;
                StartCoroutine(StartGame(1.5f));
                break;
            case ShowResult.Skipped:

                break;

            case ShowResult.Failed:

                break;

        }
    }
    
}
