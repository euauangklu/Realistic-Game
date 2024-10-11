using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabThrowChange : MonoBehaviour
{
    [SerializeField] private GameObject SetPrefab;

    public Newgod _Newgod;
    // Start is called before the first frame update
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
            _Newgod.prefab = SetPrefab;
        }
    }
}
