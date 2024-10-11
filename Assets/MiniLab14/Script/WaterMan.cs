using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMan : MonoBehaviour
{
    // Start is called before the first frame update
    private int Getscore;
    [SerializeField] private Collider _collider;
    [SerializeField] private GameObject wood;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource water;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            water.Play();
            _collider.isTrigger = true;
            wood.transform.rotation = Quaternion.Euler(0,-180,-36);
        }
    }
}
