using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell{
    Transform cellPower;
    Material color;
    //public GameObject cell;
    public Cell(float pow){
        GameObject obj = new GameObject();
        cellPower = obj.GetComponent<Transform>();
        cellPower.localScale = new Vector3(1, pow, 1);
        obj.GetComponent<Material>().color = new Color(pow, pow, pow);
    }
}

public class CellCloud : MonoBehaviour {
    public Cell[] cells;
    public Texture2D texture;
    public void MakeCells(Texture2D texture, int width, int height){
        cells = new Cell[width * height];
        Color[] colors = texture.GetPixels();
        for (int i = 0; i < width * height;i++){
            cells[i] = new Cell(colors[i].r);
        }
    }
    public void MakeCells(string path)
    {
        texture = GetTexture.GetGrayTexture(path);
        cells = new Cell[texture.width * texture.height];
        Color[] colors = texture.GetPixels();
        for(int i = 0; i< texture.width * texture.height; i++)
        {
            cells[i] = new Cell(colors[i].r);
        }
    }
}
