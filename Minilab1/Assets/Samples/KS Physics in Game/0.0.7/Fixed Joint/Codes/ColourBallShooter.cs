using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourBallShooter : MonoBehaviour
{
    [Header("Rigidbody game object to be launched")]
    [SerializeField]
    GameObject[] _gameobjects = null;
    [SerializeField] float _ballImpulseForce = 50;

    [SerializeField]
    float _lifeTime = 3;

    GameObject _nextGameObject;

    // Start is called before the first frame update
    void Start()
    {
        RandomNextGameObject();
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameObject go = _nextGameObject;
            go.SetActive(true);
            go.transform.position = ray.origin;
            Rigidbody rb = go.GetComponent<Rigidbody>();

            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.AddForce(ray.direction.normalized * _ballImpulseForce, ForceMode.Impulse);
           
            Destroy(go, _lifeTime);

            RandomNextGameObject();
        }
    }

    void RandomNextGameObject(){
        _nextGameObject = Instantiate(_gameobjects[ Random.Range(0,_gameobjects.Length)],Vector3.zero,Quaternion.identity);

        _nextGameObject.gameObject.SetActive(false);

        //_nextGameObject.transform.position = this.gameObject.transform.position;
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
        meshFilter.mesh = _nextGameObject.GetComponent<MeshFilter>().mesh;
        MeshRenderer meshRederer = this.GetComponent<MeshRenderer>();
        meshRederer.material = _nextGameObject.GetComponent<MeshRenderer>().material;
    }
    
}
