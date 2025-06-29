using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    //public GameObject startPanel;
    //public GameObject winPannel;
    public GameObject failPanel;
    public GameObject winSplash;
    public box1 box1;
    public box2 box2;
    public box3 box3;
    public box4 box4;
    public InputField[] inputs;
    public InputField[] nameInputs;
    private bool isSkip;
    public Text txt;

    private int level = 0;
    public Image[] Images;
    public Sprite[] newSprite;
    public static bool isGameOver = false;
    private liquidSpawner liquidSpawner;

    public GameObject timer;

    public Button OKBtn;
    public int empties = 0;
    public Text TimeInWin;
    public Text TimerTxt;

    public Text[] roomTimes;


    //musics

    public AudioSource audioSource;    // Reference to your AudioSource component
    public AudioClip[] MusicClip;     // The new music to play
    //public Button changeMusicButton;   // Reference to your button

    private bool hasChangedMusic = false;
    //public Button muteButton;        // Reference to the UI Button
    public Text buttonText;
    private bool isMuted = false;

    private bool isCycle;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {

            roomTimes[i].text = PlayerPrefs.GetString("cycle" + i);
            nameInputs[i].text = PlayerPrefs.GetString("names" + i);
     

        }
        if (PlayerPrefs.GetInt("Cycle") == 0)
        {
            isCycle = false;
        }
        else
        {
            isCycle = true;
        }
        buttonText.text = "Mute";
        if (Time.timeScale == 1f)
        {
            isSkip = false;
            txt.text = "1x";
        }
        else
        {
            isSkip = true;
            txt.text = "5x";
        }
        Time.timeScale = 1f;
        isGameOver = false;
        failPanel.SetActive(false);
        OKBtn.interactable = true;
        winSplash.SetActive(false);
        //timer.SetActive(false);
        liquidSpawner = GameObject.Find("bg").GetComponent<liquidSpawner>();
        //startPanel.SetActive(true);
        failPanel.SetActive(false);
        txt.text = "5x";
       
        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i].interactable = true;
           // int temp = PlayerPrefs.GetInt("key" + i);
           // int minutes = Mathf.FloorToInt(temp / 60);
           // int seconds = temp % 60;
            //string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
            inputs[i].text = PlayerPrefs.GetInt("key" + i).ToString();

            if(inputs[i].text == "0")
            {
                empties++;
            }

        }
        if (!isCycle)
        {
            for (int i = 0; i < 4; i++)
            {
                roomTimes[i].text = "";

            }
        }
          

        //music

        //changeMusicButton.onClick.AddListener(ChangeMusic);
        isMuted = PlayerPrefs.GetInt("MuteState", 0) == 1;
        audioSource.mute = isMuted;
        UpdateButtonText();
        ChangeMusic(1);
        hasChangedMusic = true;
    }
    public void ChangeMusic(int type)
    {

        if (type == 1)
        {
            audioSource.clip = MusicClip[0];

            audioSource.Play();
        }
        else if(type == 2)
        {
            audioSource.clip = MusicClip[1];

            audioSource.Play();
        }
        else if (type == 3)
        {
            audioSource.clip = MusicClip[2];

            audioSource.Play();
        }
        else if (type == 4)
        {
            audioSource.clip = MusicClip[3];

            audioSource.Play();
        }
    }

    public void ToggleMute()
    {
        // Toggle the mute state
        isMuted = !isMuted;
        audioSource.mute = isMuted;

        // Update the button text based on the mute state
        PlayerPrefs.SetInt("MuteState", isMuted ? 1 : 0);

        // Update the button text based on the new mute state
        UpdateButtonText();
  
    }
    void UpdateButtonText()
    {
        // Update the button text based on the mute state
        buttonText.text = isMuted ? "Unmute" : "Mute";
    }
    public void CalculateTime()
    {
        int temp =  PlayerPrefs.GetInt("key" + 16);
        int[] rooms = new int[4];
        rooms[0] = temp - (PlayerPrefs.GetInt("key" + 0) - PlayerPrefs.GetInt("key" + 2) - PlayerPrefs.GetInt("key" + 3));
        rooms[1] = temp - (PlayerPrefs.GetInt("key" + 4) - PlayerPrefs.GetInt("key" + 6) - PlayerPrefs.GetInt("key" + 7));
        rooms[2] = temp - (PlayerPrefs.GetInt("key" + 8) - PlayerPrefs.GetInt("key" + 10) - PlayerPrefs.GetInt("key" + 11));
        rooms[3] = temp - (PlayerPrefs.GetInt("key" + 12) - PlayerPrefs.GetInt("key" + 14) - PlayerPrefs.GetInt("key" + 15));

        //string[] times = new string[4];
      
        for (int i = 0; i < 4; i++)
        {
            //int minutes = Mathf.FloorToInt(rooms[i] / 60);
            //int seconds = rooms[i] % 60;
            //string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
            
            //roomTimes[i].text = timeString;
            PlayerPrefs.SetString("cycle" + i, rooms[i].ToString());
            print(rooms[i]);
        }
        PlayerPrefs.Save();
    }

   
    void Update()
    {
     

        TimeInWin.text = "Time: "+TimerTxt.text;
        //print(box1.isFinished1 && box2.isFinished2 && box3.isFinished3 && box4.isFinished4);
        if (box1.isFinished1 && box2.isFinished2 && box3.isFinished3 && box4.isFinished4)
        {

            timer.GetComponent<timer>().StopTimer();
            if (hasChangedMusic)
            {
                ChangeMusic(4);  // Call the ChangeMusic function
                hasChangedMusic = false;
            }
            //winPannel.SetActive(true);
            winSplash.SetActive(true);
            //winSplash.GetComponent<panelDisapear>().Hide();
           
            OKBtn.interactable = true;
            
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i].interactable = true;

            }
           
        }

        if (isGameOver)
        {
            if (hasChangedMusic)
            {
                ChangeMusic(3);  // Call the ChangeMusic function
                hasChangedMusic = false;
            }
            Time.timeScale = 0f;
            failPanel.SetActive(true);
            isGameOver = false;
        
        }
       
        if(level == 1)
        {
            Images[0].sprite = newSprite[0];
            Images[1].sprite = newSprite[1];
            Images[2].sprite = newSprite[2];
            Images[3].sprite = newSprite[3];
        }
        else  if (level == 2)
        {
            Images[0].sprite = newSprite[3];
            Images[1].sprite = newSprite[0];
            Images[2].sprite = newSprite[1];
            Images[3].sprite = newSprite[2];
        }
        else if (level == 3)
        {
            Images[0].sprite = newSprite[2];
            Images[1].sprite = newSprite[3];
            Images[2].sprite = newSprite[0];
            Images[3].sprite = newSprite[1];
        }
        else if (level == 4)
        {
            Images[0].sprite = newSprite[1];
            Images[1].sprite = newSprite[2];
            Images[2].sprite = newSprite[3];
            Images[3].sprite = newSprite[0];
        }
    }

    public void StartGame()
    {
        failPanel.SetActive(false);
        for (int i = 0; i < 4; i++)
        {
            roomTimes[i].text = "";
        }
        OKBtn.interactable = false;
        for (int i = 0;i<inputs.Length;i++)
        {
            inputs[i].interactable = false;
            PlayerPrefs.SetInt("key" + i, int.Parse(inputs[i].text));

        }
        PlayerPrefs.Save();
        //startPanel.SetActive(false);
        box1.StartBox1();
        box2.StartBox2();
        box3.StartBox3();
        box4.StartBox4();

        level++;
        if(level > 4)
        {
            level = 1;
        }
        timer.SetActive(true);
        timer.GetComponent<timer>().ResetTimer();

        if (Time.timeScale == 1f)
        {
            isSkip = false;
            txt.text = "1x";
        }
        else
        {
            isSkip = true;
            txt.text = "5x";
        }
        PlayerPrefs.SetInt("Cycle", 0);
        PlayerPrefs.Save();

        for (int i = 0;i< nameInputs.Length; i++)
        {
            PlayerPrefs.SetString("names"+i, nameInputs[i].text);
        }
        PlayerPrefs.Save();
        ChangeMusic(2);
       
    }

    public void ReTryBtn()
    {
        hasChangedMusic = true;
        OKBtn.interactable = true;
        isGameOver = false;
        failPanel.SetActive(false);
        
        //Time.timeScale = 1f;
        failPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        isGameOver = false;
        PlayerPrefs.SetInt("Cycle", 0);
        PlayerPrefs.Save();
    }
    public void MissionCompleteBtn()
    {
        hasChangedMusic = true;
        CalculateTime();
        winSplash.SetActive(false);

        if (Time.timeScale == 1f)
        {
            isSkip = false;
            txt.text = "1x";
        }
        else
        {
            isSkip = true;
            txt.text = "5x";
        }

        box1.isFinished1 = false;
        box2.isFinished2 = false;
        box3.isFinished3 = false;
        box4.isFinished4 = false;
       // OKBtn.interactable = true;
        SceneManager.LoadScene(1);
        ChangeMusic(1);
        //StartGame();
        PlayerPrefs.SetInt("Cycle", 1);
        PlayerPrefs.Save();
    }
    public void SkipBtn()
    {
        if (!isSkip)
        {
            isSkip = true;
            txt.text = "5x";
            Time.timeScale = 5.0f; // Speeds up the entire game by 5 times
        }
        else
        {
            isSkip = false;
            Time.timeScale = 1.0f; // Speeds up the entire game by 5 times
            txt.text = "1x";
        }
    }
}
