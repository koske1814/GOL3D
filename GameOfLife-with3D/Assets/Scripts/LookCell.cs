using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCell : MonoBehaviour {

    //public Transform camerapos;
    //public Transform target;
    //public Texture2D texture;
    void Start()
    {
        //camera = GetComponent<Camera>();
    }
    // Update is called once per frame
    public void LookCells (Texture2D texture) {
        this.transform.position = new Vector3(texture.width, 50, -100);
        this.transform.forward = new Vector3(texture.width / 2, 0, texture.height / 2) - this.transform.position;
    }
}
