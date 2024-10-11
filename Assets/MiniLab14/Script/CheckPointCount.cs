using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCount : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager GameManager;
    [SerializeField] private int checkpoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.minilabLevel = checkpoint;
            GameManager.LevelCheck();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.minilabLevel = checkpoint;
            GameManager.LevelCheck();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.minilabLevel = checkpoint;
            GameManager.LevelCheck();
        }
    }
}
