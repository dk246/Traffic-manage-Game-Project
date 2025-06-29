using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VeryFirstFunc : MonoBehaviour
{


    public GameObject FakeBtn;
    public GameObject RealBtn;

    void Start()
    {
        if(PlayerPrefs.GetInt("clickedBtn") == 1)
        {
            RealBtn.SetActive(true);
            FakeBtn.SetActive(false);
        }
        else
        {
            RealBtn.SetActive(false);
            FakeBtn.SetActive(true);
        }
    }

    public void StartGameBtn()
    {
        PlayerPrefs.SetInt("key" + 0, 20);
        PlayerPrefs.SetInt("key" + 2, 20);
        PlayerPrefs.SetInt("key" + 4, 20);
        PlayerPrefs.SetInt("key" + 6, 20);
        PlayerPrefs.SetInt("key" + 8, 20);
        PlayerPrefs.SetInt("key" + 10, 20);
        PlayerPrefs.SetInt("key" + 12, 20);
        PlayerPrefs.SetInt("key" + 14, 20);
        PlayerPrefs.SetInt("key" + 16, 180);
        PlayerPrefs.SetInt("clickedBtn", 1);
        PlayerPrefs.SetInt("MuteState", 0);
        PlayerPrefs.SetInt("Cycle", 0);
        PlayerPrefs.Save();
    }

    void Update()
    {
        
    }
}
