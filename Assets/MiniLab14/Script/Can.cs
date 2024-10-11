using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    private int Getscore;
    [SerializeField] private AudioSource audioSource;
    public AudioClip CanSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = CanSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Getscore = PlayerPrefs.GetInt("Score");
            Getscore += 1;
            PlayerPrefs.SetInt("Score",Getscore);
            audioSource.Play();
        }
    }
}
