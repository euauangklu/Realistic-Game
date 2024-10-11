using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private String gamename;
    private bool Gamestart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamestart)
        {
            text.text = "Game : " + gamename + "    Score : " + PlayerPrefs.GetInt("Score");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Score", 0);
            Gamestart = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Gamestart = false;
        }
    }
}
