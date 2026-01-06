using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    [SerializeField]
    public Bullet monData;
   public  Rigidbody rb;
    private void Update()
    {
        transform.Translate(Vector3.forward * monData.speed * Time.deltaTime, Space.Self);
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        rb.velocity = Vector3.zero;
        StartCoroutine(ReturnCo(2f));
    }
    private void OnTriggerEnter(Collider other)
    {
        PoolManager.instance.ReturnPool(gameObject);
    }
    IEnumerator ReturnCo(float t)
    {
        yield return new WaitForSeconds(t);
        PoolManager.instance.ReturnPool(gameObject);
    }
}
