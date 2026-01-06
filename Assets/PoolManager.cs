using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance = null;
    Queue<GameObject> pool;
    public GameObject targetObj;
    public int poolSize;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    // Start is called before te first frame update
    void Start()
    {
        pool = new Queue<GameObject>();
        for(int i=0; i<poolSize; i++)
        {
            GameObject newObj = Instantiate(targetObj);
            newObj.SetActive(false);
            pool.Enqueue(newObj);
        }
        
    }

    public GameObject UsePool(Vector3 pos, Quaternion rot)
    {
        GameObject useObj= pool.Dequeue();
        useObj.transform.SetPositionAndRotation(pos, rot);
       //useObj.transform.position = pos;
       //useObj.transform.rotation = rot;
        useObj.SetActive(true);
        return useObj;

    }
    public void ReturnPool(GameObject returnObj)
    {
        returnObj.SetActive(false);
        pool.Enqueue(returnObj);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UsePool(transform.position,transform.rotation);
        }
    }
}
