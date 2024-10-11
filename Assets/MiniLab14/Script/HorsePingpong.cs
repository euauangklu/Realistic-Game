using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsePingpong : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 HorseMovementSpeed = new Vector3(0f, 0f, 0f);
    private float timer;
    [SerializeField] private float Timemove;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.fixedDeltaTime;
        transform.position += HorseMovementSpeed;
        if (timer >= Timemove)
        {
            HorseMovementSpeed *= -1f;
            ResetTime();
        }
    }

    public void ResetTime()
    {
        timer = 0;
    }
}
