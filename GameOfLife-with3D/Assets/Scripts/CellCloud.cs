using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CellCloud : MonoBehaviour {
    public Cell[,] cells { get; set; }
    public Transform[,] pos { get; set; }
    public Texture2D texture { get; private set; }
    [SerializeField]
    GameObject cellObj;
    [SerializeField]
    Transform cloud;
    public void MakeCell(Texture2D texture)
    {
        this.texture = texture;
        cells = new Cell[texture.width,texture.height];
        for(int i = 0; i<texture.width; i++)
        {
            for (int j = 0; j < texture.height;j++)
            {
                GameObject obj = (GameObject)Instantiate(cellObj);
                obj.transform.SetParent(cloud);
                cells[i, j] = obj.GetComponent<Cell>();
                cells[i, j].transform.position = new Vector3(i, 0, j);
                cells[i, j].SetCell(cells,texture.GetPixel(i,j).r);
            }
        }
    }

    public void Transition(){
        float[,] sizes = new float[texture.width, texture.height];
        for (int i = 0; i < texture.width;i++){
            for (int j = 0; j < texture.height;j++){
                sizes[i,j] = cells[i, j].Transition(cells, i, j);
            }
        }
        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                cells[i, j].SetCell(cells, sizes[i, j]);
            }
        }
    }

}
