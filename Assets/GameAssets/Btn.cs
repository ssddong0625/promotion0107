using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IChangeAble
{
    void Active();
}
public class Btn : MonoBehaviour
{
    public GameObject targetObj;
    public void Click()
    {
        Debug.Log("µþ±ï");
        if (targetObj.GetComponent<IChangeAble>() != null)
        {
            targetObj.GetComponent<IChangeAble>().Active();
        }
    }
}
