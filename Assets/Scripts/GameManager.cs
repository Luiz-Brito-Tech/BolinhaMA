using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private PlayerController player;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private AudioSource mgMusic;
    private float timer = 200f;

    void SetTimer(float decrease)
    {
        timer -= decrease * Time.deltaTime;
        timerText.text = "Tempo: " + timer.ToString();
    }

    void Start()
    {
        SetTimer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            SetTimer(1);
        }
        else
        {
            player.Death();
        }
    } 

    public void VictoryScreen()
    {
        timer = 200f;
        mgMusic.Stop();
        winScreen.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
