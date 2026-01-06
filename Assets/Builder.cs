using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class Bullet
{
    [SerializeField]
    public float speed;
    [SerializeField]
    private int atk;
    [SerializeField]
    private string name;
    public Bullet(float speed, int atk, string name)
    {
        this.speed = speed;
        this.atk = atk;
        this.name = name;
    }
}
public class BulletBuilder
{
    private float speed;
    private int atk;
    private string name;
    public Transform SpawnPoint;
    
    public BulletBuilder( Transform SpawnPoint)
    {
        this.SpawnPoint = SpawnPoint;
    }
    public BulletBuilder SetSpeed(float speed)
    {
        this.speed = speed;
        return this;
    }
    public BulletBuilder SetAtk(int atk)
    {
        this.atk = atk;
        return this;
    }
    public BulletBuilder SetName(string name)
    {
        this.name = name;
        return this;
    }
    public void Build()
    {
        GameObject newObj = PoolManager.instance.UsePool(SpawnPoint.position, SpawnPoint.rotation);
        BulletComponent mc = newObj.GetComponent<BulletComponent>();
        mc.monData = new Bullet(speed, atk, name);
    }
}
public class Builder : MonoBehaviour
{
    public Transform spawnPoint;
    public BulletBuilder monsterBuilder;
    // Start is called before the first frame update
    public void Awake()
    {
        monsterBuilder = new BulletBuilder(spawnPoint);
        monsterBuilder.SetSpeed(10)
                      .SetAtk(5)
                      .SetName("기본 총알");
        Debug.Log("기본 상태");
        
    }
    public void SetBulletSpeed(float speed)
    {
        monsterBuilder.SetSpeed(speed);
    }
    public void SetBulletName(string name)
    {
        monsterBuilder.SetName(name);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            monsterBuilder.Build();
        }
    }
}
