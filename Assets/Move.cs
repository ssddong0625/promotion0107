using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class MoveStretegy
{
    protected NavMeshAgent agent;
    public void SetAgent(NavMeshAgent agent)
    {
        this.agent = agent;
    }
    public abstract void moveSpeed();
}

public class MoveOneStepStretegy : MoveStretegy
{
    public override void moveSpeed()
    {
        agent.speed = 10f;
    }
}
public class MoveTwoStepStretegy : MoveStretegy
{
    public override void moveSpeed()
    {
        agent.speed = 20f;
    }
}

public class MoveThreeStepStretegy : MoveStretegy
{
    public override void moveSpeed()
    {
        agent.speed = 30f;
    }
}
public class MoveNormalStretegy : MoveStretegy
{
    public override void moveSpeed()
    {
        agent.speed = 5f;
    }
}
public class Move : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private NavMeshAgent agent;
    MoveStretegy moveStretegy;
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
        moveStretegy = new MoveNormalStretegy();
        moveSpeed();

    }
    public void moveSpeed()
    {
        moveStretegy.SetAgent(agent);
        moveStretegy.moveSpeed();
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
            moveStretegy = new MoveOneStepStretegy();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("속도 2단계");
            moveStretegy = new MoveTwoStepStretegy();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("속도 3단계");
            moveStretegy = new MoveThreeStepStretegy();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("속도 기본 단계");
            moveStretegy = new MoveNormalStretegy();
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
