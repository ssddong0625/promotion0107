using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IMoveStretegy
{
    void MoveSpeed(NavMeshAgent agent);
}
public class MoveManager
{
    IMoveStretegy moveStretegy;
    public void SetStretegy(IMoveStretegy ms)
    {
        moveStretegy = ms;
    }
    public void MoveSpeed(NavMeshAgent agent)
    {
        moveStretegy.MoveSpeed(agent);
    }
}

public class MoveOneStepStretegy : IMoveStretegy
{
    public void MoveSpeed(NavMeshAgent agent)
    {
        agent.speed = 10f;
    }
}
public class MoveTwoStepStretegy : IMoveStretegy
{
    public void MoveSpeed(NavMeshAgent agent)
    {
        agent.speed = 20f;
    }
}

public class MoveThreeStepStretegy : IMoveStretegy
{
    public void MoveSpeed(NavMeshAgent agent)
    {
        agent.speed = 30f;
    }
}
public class MoveNormalStretegy : IMoveStretegy
{
    public void MoveSpeed(NavMeshAgent agent)
    {
        agent.speed = 5f;
    }
}
public class Move : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private NavMeshAgent agent;
    public MoveManager moveManager;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (cam == null)
        {
            cam = Camera.main;
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        Btn btn = other.GetComponent<Btn>();
        if (btn != null)
        {
            btn.Click();
        }
    }
    private void Start()
    {
        moveManager = new MoveManager();
        moveManager.SetStretegy(new MoveNormalStretegy());
        moveSpeed();

    }
    public void moveSpeed()
    {
        moveManager.MoveSpeed(agent);
    }
    void Moving()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,999f))
            {
                agent.SetDestination(hit.point);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("속도 1단계");
            moveManager.SetStretegy(new MoveOneStepStretegy());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("속도 2단계");
            moveManager.SetStretegy(new MoveTwoStepStretegy());
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("속도 3단계");
            moveManager.SetStretegy(new MoveThreeStepStretegy());
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("속도 기본 단계");
            moveManager.SetStretegy(new MoveNormalStretegy());
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("속도 적용");
            moveSpeed();
        }

    }
    void Update()
    {
        Moving();
    }
}
