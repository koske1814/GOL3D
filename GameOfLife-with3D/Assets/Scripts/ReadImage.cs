using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadImage : MonoBehaviour {

    [SerializeField]
    private UnityEngine.UI.Image m_image = null;

    const string _FILE_HEADER = "file://";
    private IEnumerator LoadImage(string path){
        if(!System.IO.File.Exists(path)){
            Debug.Log("File does not exist. path" + path);
            yield break;
        }
        WWW request = new WWW(_FILE_HEADER + path);
        while(!request.isDone){
            yield return new WaitForEndOfFrame();
        }

        Texture2D texture = request.texture;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),new Vector2(0.5f,0.5f));
        m_image.sprite = sprite;
        yield return 0;

    }

}
