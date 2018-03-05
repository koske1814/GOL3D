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
        Image image = obj.GetComponent<Image>();
        Texture2D texture = GetTexture.GetGrayTexture(Application.dataPath + "/Image/img.png");
        image.material.mainTexture = texture;
        CellCloud cellCloud = new CellCloud(texture);
    }
}
