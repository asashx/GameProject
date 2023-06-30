using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    public GameObject buildcanvas;

    void Update(){
        
    Camera camera = Camera.main;
    
    buildcanvas.transform.LookAt(buildcanvas.transform.position + (camera.transform.rotation * Vector3.back), camera.transform.rotation * Vector3.up);
    }
  
}

