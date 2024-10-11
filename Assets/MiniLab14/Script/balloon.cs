using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloon : MonoBehaviour
{
    // Start is called before the first frame update
    private int Getscore;
    [SerializeField] private AudioSource audioSource;
    public AudioClip popSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = popSound;
        audioSource.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dart"))
        {
            Getscore = PlayerPrefs.GetInt("Score");
            Getscore += 1;
            PlayerPrefs.SetInt("Score",Getscore);
            if (audioSource.enabled && audioSource.clip != null)
            {
                audioSource.Play();
                Destroy(gameObject, popSound.length / 2.75f);
            }
            else
            {
                Debug.LogWarning("AudioSource is not enabled or AudioClip is missing!");
            }
        }
    }
}
