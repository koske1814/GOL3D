using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour
{

    private static GameObject mOriginal;
    private static Stack<T> mObjPool = new Stack<T>();

    public static void SetOriginal(GameObject origin)
    {
        mOriginal = origin;

    }

    public static T Create()
    {
        T obj;
        if (mObjPool.Count > 0){
            obj = Pop();
        }
        else{
            var go = Instantiate<GameObject>(mOriginal);
            obj = go.GetComponent<T>();
        }
        (obj as ObjectPool<T>).Init();
        return obj;
    }

    private static T Pop(){
        var ret = mObjPool.Pop();
        return ret;
    }


    private static void Pool(T obj){
        (obj as ObjectPool<T>).Sleep();
        mObjPool.Push(obj);
    }

    private static void Clear(){
        mObjPool.Clear();
    }

    public abstract void Init();
    public abstract void Sleep();
}
