using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
    private void Awake()
    {
    }

    public void Transition(){
        
    }

    public void SetCell(Vector3 pos,Vector3 scale){
        this.transform.position = pos;
        this.transform.localScale = scale;
        //SetColor(new Color(scale.y,scale.y,scale.y));
    }

    private void SetColor(Color color){
        GetComponent<Renderer>().material.color = color;
    }

}
