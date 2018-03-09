using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCell : MonoBehaviour {

    Camera camera;
    public Transform target;

    void Start()
    {
        camera = GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update () {
        camera.transform.LookAt(target);
        camera.transform.position = target.position + new Vector3(-20, 100, -20);
    }
}
