using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CellCloud : MonoBehaviour {
    public Cell[,] cells { get; set; }
    public Transform[,] pos { get; set; }
    public Texture2D texture { get; private set; }
    public float updateInterval = 0.1f;
    public GameObject cellObj;
    public Transform cloud;

    public enum Status
    {
        Idle, Running
    }

    public Status state = Status.Idle;
    private Action CellUpdates;
    private Action CellApplyUpdates;

    private IEnumerator coroutine;

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
                cells[i, j].SetCell(texture.GetPixel(i,j).r);
                cells[i, j].neighbor = GetNeighbor(i, j);
                CellUpdates += cells[i, j].CellUpdate;
                //CellApplyUpdates += cells[i, j].CellApply;
            }
        }
    }

    private Cell[] GetNeighbor(int y,int x){
        Cell[] result = new Cell[8];
        result[0] = cells[NeighborOutRange(y - 1, texture.width), NeighborOutRange(x - 1, texture.height)];
        result[1] = cells[NeighborOutRange(y - 1, texture.width), NeighborOutRange(x, texture.height)];
        result[2] = cells[NeighborOutRange(y - 1, texture.width), NeighborOutRange(x + 1, texture.height)];
        result[3] = cells[NeighborOutRange(y, texture.width), NeighborOutRange(x - 1, texture.height)];
        result[4] = cells[NeighborOutRange(y, texture.width), NeighborOutRange(x + 1, texture.height)];
        result[5] = cells[NeighborOutRange(y + 1, texture.width), NeighborOutRange(x - 1, texture.height)];
        result[6] = cells[NeighborOutRange(y + 1, texture.width), NeighborOutRange(x, texture.height)];
        result[7] = cells[NeighborOutRange(y + 1, texture.width), NeighborOutRange(x + 1, texture.height)];
        return result;
    }

    private int NeighborOutRange(int n, int range)
    {
        if (n < 0) return range - 1;
        if (n >= range) return 0;
        return n;
    }

    public void Transition(){
        CellUpdates();
        CellApplyUpdates();
    }

    public void Run(){
        state = Status.Running;
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = RunCoroutine();
        StartCoroutine(coroutine);
    }

    public void Stop(){
        state = Status.Idle;
    }

    private IEnumerator RunCoroutine(){
        while(state == Status.Running){
            Transition();
            yield return new WaitForSeconds(updateInterval);
        }

    }

}
