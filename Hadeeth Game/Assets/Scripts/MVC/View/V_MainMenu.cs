using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class V_MainMenu : MonoBehaviour
{
    #region public vars
    public GameObject settingsPanel;
    public GameObject soundPanel;
    public GameObject languagePanel;
    public GameObject videoPanel;
    public GameObject blurLayer;
    public Toggle toggle;
    public Toggle MuteMusic;
    public Toggle MuteAll;
    public Toggle Sound;
    public Toggle Arabic;
    public Toggle Graphics;
    public Slider example;
    #endregion
    void Start()
    {
        InitializeSettings();
    }
    public void InitializeSettings()
    {
        string jsonResult;
        if (File.Exists(Application.persistentDataPath + "//Settings.json"))
        {
            jsonResult = File.ReadAllText(Application.persistentDataPath + "//Settings.json");
            Settings settings = JsonUtility.FromJson<Settings>(jsonResult);
            MuteMusic.isOn = settings.MuteMusic;
        }
    }

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
        string subject = "Hadeeth Game";
        string body = "Try Hadeeth by Joybox it is an amazing game";
        //execute the below lines if being run on a Android device
#if UNITY_ANDROID
         //Refernece of AndroidJavaClass class for intent
          AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
         //Refernece of AndroidJavaObject class for intent
         AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
         //call setAction method of the Intent object created
         intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
         //set the type of sharing that is happening
         intentObject.Call<AndroidJavaObject>("setType", "text/plain");
         //add data to be passed to the other activity i.e., the data to be sent
         intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
         intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
         //get the current activity
         AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
         AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
         //start the activity by sending the intent data
         currentActivity.Call("startActivity", intentObject);
         intentClass.Dispose();
         unity.Dispose();

#endif
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
        string json = "{MuteMusic }";
        File.WriteAllText(Application.persistentDataPath + "//Settings.json", json);
        blurLayer.SetActive(false);
        settingsPanel.SetActive(false);
    }


}
