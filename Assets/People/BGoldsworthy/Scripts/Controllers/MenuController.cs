using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    #region Unity Editor Values
    [Header("Panels")]
    public GameObject MainUI;
    private List<GameObject> panels = new List<GameObject>();
    private GameObject MainMenuPanel;
    private GameObject OptionsPanel;
    private GameObject CreditsPanel;
    private GameObject PausePanel;
    private GameObject InstructionsPanel;
    private GameObject GamePanel;
    private GameObject VideoPanel;

    [Header("Other")]
    public GameController gameController;
    public AudioController audioController;
    public AudioMixer mixer;
    List<GameObject> gameObjects = new List<GameObject>();
    private int playing;
    private RectTransform audiosPanel;
    private RectTransform controlsPanel;
    public bool hovering = false;
    private bool startup = false;
    public List<Image> images;
    public bool paused;
    public bool nationSelected = false;
    public GameObject eventWindow;
    [SerializeField] GameObject startText;
    private float scaleMultiplier = 1.0f;
    bool swapper = true;
    [SerializeField] float rateOfChange = 0.001f;

    #endregion

    #region Start/Awake/Enable

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioController = GameObject.Find("Controllers").GetComponent<AudioController>();
        gameController = GameObject.Find("Controllers").GetComponent<GameController>();
    }

    private void Start()
    {
        populatePanels();
        Disable();
        Time.timeScale = 0;
        GameController.Instance.state = eState.TITLE;
        if (GameController.Instance.state == eState.TITLE)  
        {
            VideoPanel.SetActive(true);
            MainMenuPanel.SetActive(true);
        }
        menuTrackPlayer();
        if (controlsPanel != null && audiosPanel != null)
        {
            controlsPanel.gameObject.SetActive(false);
            audiosPanel.gameObject.SetActive(true);
        }
        
    }

    private void OnEnable()
    {
        
    }

    private void Update()
    {
       if(GameController.Instance.state == eState.TITLE && startText != null)
       {
            if (scaleMultiplier <= 1.2f && swapper == true)
            {
                scaleMultiplier += rateOfChange;
                if(scaleMultiplier >= 1.2f)
                {
                    swapper = false;
                }
            }
            else if (scaleMultiplier >= 0.8f && swapper == false)
            {
                scaleMultiplier -= rateOfChange;
                if (scaleMultiplier <= 0.8f)
                {
                    swapper = true;
                }
            }
            startText.transform.localScale = new Vector3(1, 1, 1) * scaleMultiplier;
            
       }
    }

    private bool IsPointerOverUIObject(int val)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > val;
    }

    #endregion

    #region Audio
    private void menuTrackPlayer()
    {
        universalAudioPlayer();
    }

    private void audioStopper()
    {
        audioController.Stop("Track" + playing);
    }

    private void universalAudioPlayer()
    {
        if (startup)
        {
            audioStopper();
        }

        audioController.Play("Track1");
        playing = 1;
        if (startup == false) startup = true;
    }

    private void sceneTrackPlayer()
    {
        //audioController.Stop("Track" + playing);
        //int trackPlay = UnityEngine.Random.Range(0, 2);
        //if (trackPlay == 1)
        //{
        //    audioController.Play("Track5");
        //    playing = 5;
        //    Debug.Log("Track 5 played");
        //}
        //else
        //{
        //    audioController.Play("Track9");
        //    playing = 9;
        //    Debug.Log("Track 9 played");
        //}
        universalAudioPlayer();
    }

    private void gameTrackPlayer()
    {
        audioController.Stop("Track" + playing);
        int trackPlay = UnityEngine.Random.Range(0, 4);
        if (trackPlay == 1)
        {
            audioController.Play("Track2");
            Debug.Log("Track 1 played");
            playing = 1;
        }
        else if (trackPlay == 2)
        {
            audioController.Play("Track3");
            Debug.Log("Track 2 played");
            playing = 2;
        }
        else if (trackPlay == 3)
        {
            audioController.Play("Track4");
            Debug.Log("Track 3 played");
            playing = 3;
        }
        else
        {
            audioController.Play("Track5");
            Debug.Log("Track 4 played");
            playing = 4;
        }
    }

    #endregion

    #region Panel Changing

    private void populatePanels()
    {
        MainUI.SetActive(true);
        foreach (Transform child in MainUI.transform)
        {
            child.gameObject.SetActive(true);
            foreach (Transform grandChild in child)
                grandChild.gameObject.SetActive(true);
        }
        RectTransform[] transforms = MainUI.GetComponentsInChildren<RectTransform>();
        foreach (RectTransform child in transforms)
        {
            if (child.gameObject.CompareTag("UI"))
            {
                child.gameObject.SetActive(true);
                panels.Add(child.gameObject);
                Debug.Log(child.name);
                if (child.name == "MainMenuPanel") { MainMenuPanel = child.gameObject; }
                if (child.name == "OptionsPanel") { OptionsPanel = child.gameObject; }
                if (child.name == "CreditsPanel") { CreditsPanel = child.gameObject; }
                if (child.name == "PausePanel") { PausePanel = child.gameObject; }
                if (child.name == "InstructionsPanel") { InstructionsPanel = child.gameObject; }
                if (child.name == "GamePanel") { GamePanel = child.gameObject; }
                if (child.name == "VideoPanel") { VideoPanel = child.gameObject; }
            }
        }
    }

    public void Disable()
    {
        foreach (GameObject gameObject in panels)
        {
            gameObject.SetActive(false);
        }
    }
    public void StartGame()
    {
        Disable();
        audioController.Stop("Track" + playing);
        GamePanel.SetActive(true);
        gameTrackPlayer();
        Time.timeScale = 1;
        GameController.Instance.state = eState.GAME;
        SceneManager.LoadScene("Game");
    }

    public void ResumeGame()
    {
        Disable();
        Time.timeScale = 1;
        GamePanel.SetActive(true);
        GameController.Instance.state = eState.GAME;
        Debug.Log("Resume Game");
    }

    public void Options()
    {
        Disable();
        OptionsPanel.SetActive(true);
        if (GameController.Instance.state == eState.TITLE)
        {
            VideoPanel.SetActive(true);
        }
        Debug.Log("Options menu");
    }

    public void Instructions()
    {
        Disable();
        InstructionsPanel.SetActive(true);
        if (GameController.Instance.state == eState.TITLE)
        {
            VideoPanel.SetActive(true);
        }
        //GameController.Instance.state = eState.INSTRUCTIONS;
    }

    public void Credits()
    {
        Disable();
        CreditsPanel.SetActive(true);
        if (GameController.Instance.state == eState.TITLE)
        {
            VideoPanel.SetActive(true);
        }
        Debug.Log("Credits menu");
    }
    public void Pause()
    {
        if (GameController.Instance.state == eState.GAME)
        {
            //Disabled timescale since its an action based multiplayer game
            Time.timeScale = 1;
            Disable();
            PausePanel.SetActive(true);
            GameController.Instance.state = eState.PAUSE;
        }
    }

    public void displayAudio()
    {
        controlsPanel.gameObject.SetActive(false);
        audiosPanel.gameObject.SetActive(true);
    }

    public void displayKeys()
    {
        audiosPanel.gameObject.SetActive(false);
        controlsPanel.gameObject.SetActive(true);
    }

    #endregion

    #region Back
    public void Back()
    {
        Disable();

        if (GameController.Instance.state == eState.PAUSE)
        {
            BackToPause();
        }
        else
        {
            BackToMenu();
        }
    }

    //Back to main menu
    public void BackToMenu()
    {
        Disable();
        if (SceneManager.GetActiveScene().name != "Main")
        {
            SceneManager.LoadScene("Main");
        }
        GamePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        GameController.Instance.state = eState.TITLE;
        if (GameController.Instance.state == eState.TITLE)
        {
            VideoPanel.SetActive(true);
        }
    }

    //Back to pause menu
    public void BackToPause()
    {
        Disable();
        PausePanel.SetActive(true);
        GameController.Instance.state = eState.PAUSE;
    }

    #endregion
    
    #region Set Audio Levels
    public void SetLevelMST(float sliderValue)
    {
        if (sliderValue == 0)
        {
            mixer.SetFloat("MST", -80);
        }
        else
        {
            mixer.SetFloat("MST", Mathf.Log10(sliderValue) * 20);
        }
    }

    public void SetLevelBGM(float sliderValue)
    {
        Debug.Log(sliderValue);
        if (sliderValue == 0)
        {
            mixer.SetFloat("BGM", -80);
        }
        else
        {
            mixer.SetFloat("BGM", Mathf.Log10(sliderValue) * 20);
        }
    }

    public void SetLevelSFX(float sliderValue)
    {
        if (sliderValue == 0)
        {
            mixer.SetFloat("SFX", -80);
        }
        else
        {
            mixer.SetFloat("SFX", Mathf.Log10(sliderValue) * 20);
        }
    }
    public void SetLevelAMB(float sliderValue)
    {
        if (sliderValue == 0)
        {
            mixer.SetFloat("AMB", -80);
        }
        else
        {
            mixer.SetFloat("AMB", Mathf.Log10(sliderValue) * 20);
        }
    }
    public void SetLevelPitch(float sliderValue)
    {
        mixer.SetFloat("Pitch", sliderValue);
    }

    public void Mute(bool mute)
    {
        if (mute) mixer.SetFloat("MST", -80);
        else mixer.SetFloat("MST", 0);
    }

    #endregion

    #region Reset/Exit Game
    public void ResetApplication()
    {
        Disable();
        var scene = GameObject.Find("Scene").GetComponent<Transform>();
        Destroy(scene.root.gameObject);
        SceneManager.LoadScene("Main");

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    #endregion
}