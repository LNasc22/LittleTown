using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GanfaulMoviment : MonoBehaviour
{
    NavMeshAgent navAgent;
    public Transform target;
    public float idleSpeed;
    public float walkSpeed;
    public float runSpeed;
    public Animator animator;
    public bool triggerGuard;
    public bool triggerArissa;
    public bool triggerDecision;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

        triggerGuard = false;
        triggerArissa = false;
        triggerDecision = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!navAgent.hasPath)
        {
            navAgent.speed = idleSpeed;
            animator.SetFloat("speed", 0f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            navAgent.SetDestination(target.position);

            navAgent.speed = walkSpeed;
            animator.SetFloat("speed", 1f);
        }
        if (navAgent.speed > 0)
            if (Input.GetKey(KeyCode.LeftShift))
            {
                navAgent.speed = runSpeed;
                animator.SetFloat("speed", 6f);
            }
        if (navAgent.isOnOffMeshLink)
        {
            animator.SetBool("hasJumpped", true);
        }
        if (!navAgent.isOnOffMeshLink)
        {
            animator.SetBool("hasJumpped", false);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "guard")
            triggerGuard = true;
        if (other.tag == "arissa")
            triggerArissa = true;
        if (other.tag == "decision")
            triggerDecision = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "guard")
        {
            triggerGuard = false;
            Dialogues.FindObjectOfType<Dialogues>().textBox.text = "";
        }
            
        if (other.tag == "arissa")
        {
            triggerArissa = false;
            Dialogues.FindObjectOfType<Dialogues>().textBox.text = "";
        }

        if (other.tag == "decision")
        {
            triggerDecision = false;
            Dialogues.FindObjectOfType<Dialogues>().textBox.text = "";
        }
    }
}
