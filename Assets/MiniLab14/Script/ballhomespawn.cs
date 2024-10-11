using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballhomespawn : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float launchForce = 10f; 
    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {

        timer -= Time.deltaTime;


        if (timer <= 0f)
        {
            SpawnBall();
            timer = spawnInterval;
        }
    }

    void SpawnBall()
    {

        if (prefab != null && spawnPosition != null)
        {
            GameObject newBall = Instantiate(prefab, spawnPosition.position, spawnPosition.rotation);


            Renderer renderer = newBall.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = GetRandomColor();
            }
            Rigidbody rb = newBall.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = newBall.AddComponent<Rigidbody>();
            }
            
            rb.AddForce(spawnPosition.forward * launchForce, ForceMode.Impulse);
        }
        else
        {
           
        }
    }

    Color GetRandomColor()
    {

        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        return new Color(r, g, b);
    }
}