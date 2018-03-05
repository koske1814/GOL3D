using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenItemBar : MonoBehaviour {
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    GameObject img;
    public void OnClick()
    {
        GameObject obj = (GameObject)Instantiate(img);
        obj.transform.SetParent(canvas.transform, false);
        Image texture = obj.GetComponent<Image>();
        texture.material.mainTexture = GetTexture.GetGrayTexture(Application.dataPath + "/Image/img.png");
        //texture.GetComponent<RectTransform>().sizeDelta = new Vector2();
        //texture.GetComponent<RectTransform>().position = new Vector3();
        //texture.transform.localScale = new Vector3(5, 5, 5);
        
        this.gameObject.SetActive(false);
    }
}
