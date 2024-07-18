using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class VectorVisualisation : MonoBehaviour
{
        [SerializeField] protected float lineSize=0.2f;
        [SerializeField] protected Material lineMaterial;
        [SerializeField] protected Rigidbody mRigidbody;
     
        protected LineRenderer lineRenderer;
        protected virtual void Start()
         {
         if(mRigidbody== null)
             {
             mRigidbody=GetComponentInParent<Rigidbody>();
             }
         lineRenderer=gameObject.AddComponent<LineRenderer>();
        
         if(lineMaterial!= null){
             lineRenderer.material=lineMaterial;
             }
        
         lineRenderer.startWidth=lineSize;
         lineRenderer.endWidth=0;
         }

 protected virtual void FixedUpdate(){
    
     }

 }
