using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class V_MainMenu : MonoBehaviour
{
    #region public vars
    public GameObject settingsPanel;
    public GameObject soundPanel;
    public GameObject languagePanel;
    public GameObject videoPanel;
    public GameObject blurLayer;
    #endregion
    public void ClickQuit()
    {
        Application.Quit();
    }
    public void ClickStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void ClickSettings()
    {
        blurLayer.SetActive(true);
        settingsPanel.SetActive(true);

    }
    public void ClickShare()
    {

    }

    public void ClickSound()
    {
        soundPanel.SetActive(true);
        languagePanel.SetActive(false);
        videoPanel.SetActive(false);
    }

    public void ClickLanguage()
    {
        soundPanel.SetActive(false);
        languagePanel.SetActive(true);
        videoPanel.SetActive(false);
    }
    public void ClickVideo()
    {
        soundPanel.SetActive(false);
        languagePanel.SetActive(false);
        videoPanel.SetActive(true);
    }
    public void ClickConfirm()
    {
        blurLayer.SetActive(false);
        settingsPanel.SetActive(false);
    }



}
