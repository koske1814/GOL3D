using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FindImages : MonoBehaviour {

    [SerializeField]
    private GameObject scrollBtn;
    [SerializeField]
    private Transform content;
    private ReadTexture texture;
    public void DisplayFile(string path)
    {
        string[] dirs = System.IO.Directory.GetDirectories(path);
        string[] files = System.IO.Directory.GetFiles(path);

        foreach (string dir in dirs)
        {
            GameObject obj = (GameObject)Instantiate(scrollBtn);
            obj.transform.SetParent(content, false);
            string[] dirName = dir.Split('/');
            obj.GetComponentInChildren<Text>().text = dirName[dirName.Length - 1];
            obj.GetComponent<Button>().onClick.AddListener(() => DisplayFile(dir));
            Debug.Log(dir);
        }

//        foreach (string file in files)
//        {
//            GameObject obj = (GameObject)Instantiate(scrollBtn);
//            obj.transform.SetParent(content, false);
//            string[] fileName = file.Split('/');
//            obj.GetComponentInChildren<Text>().text = fileName[fileName.Length - 1];
//            obj.GetComponent<Button>().onClick.AddListener(() => OnClick(file));

//        }
    }

    public void OnClick(string path){
        
    }
}
