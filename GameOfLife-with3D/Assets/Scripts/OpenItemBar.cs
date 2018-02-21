using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenItemBar : MonoBehaviour {
    [SerializeField]
    private GameObject scBar;
    [SerializeField]
    private Transform canvas;

    public void OnClick(){
        GameObject obj = (GameObject)Instantiate(scBar);
        obj.transform.SetParent(canvas,false);
        obj.transform.position = new Vector3();
        obj.GetComponent<FindImages>().DisplayFile("/Users/sakatakoske/");
    }
}
