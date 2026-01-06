using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAdapt : MonoBehaviour, IChangeAble
{
    public Builder builder;
    public float bulletSpeed ;
    public string bulletName;

    public void Awake()
    {
        if (builder == null)
        {
            builder = GetComponent<Builder>();
        }
    }
    
    public void Active()
    {
        builder.SetBulletSpeed(bulletSpeed);
        builder.SetBulletName(bulletName);
        Debug.Log(bulletSpeed);
        Debug.Log(bulletName);
    }

  

    
}
