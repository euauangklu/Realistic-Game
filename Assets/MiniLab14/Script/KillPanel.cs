using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPanel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject oldcanvas;
    [SerializeField] private GameObject newcanvas;
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
            oldcanvas.SetActive(false);
            newcanvas.SetActive(true); 
        }
    }
}
