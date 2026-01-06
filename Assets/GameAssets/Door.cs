using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour,IChangeAble
{
    bool isopen;
    int rotate = 5000;
    public void Active()
    {
        if (isopen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }
    public void Open()
    {
        Debug.Log("¹®¿­¸²");
        isopen = true;
        transform.Rotate(Vector3.up * rotate * Time.deltaTime, Space.Self);
    }
    public void Close()
    {
        Debug.Log("¹®´ÝÈû");
        isopen = false;
        transform.Rotate(Vector3.down * rotate * Time.deltaTime, Space.Self);
    }
    
}
