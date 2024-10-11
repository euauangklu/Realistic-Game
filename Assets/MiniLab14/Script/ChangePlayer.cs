using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager GameManager;
    [SerializeField] private GameObject Oldplayer;
    [SerializeField] private GameObject Newplayer;
    [SerializeField] private CinemachineFreeLook FreeLook;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Oldplayer.SetActive(false);
        Newplayer.SetActive(true);
        FreeLook.LookAt = Newplayer.transform;
        FreeLook.Follow = Newplayer.transform;
        GameManager.playerPos = Newplayer.transform;
    }
}
