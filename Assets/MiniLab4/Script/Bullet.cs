using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
         {
         //Destroy itself
         Destroy(gameObject, 1);
         }
}
