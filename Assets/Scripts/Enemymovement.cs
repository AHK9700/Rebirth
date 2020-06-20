using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    public float LookRadius = 10f;
    //The target is the player
    Transform target;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //you need a refrence in the player manger to the player
        target = PlayerManger.instance.player.transform;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Vector3.Distance(target.position, transform.position);

        if (Distance <= LookRadius)

        {
            agent.SetDestination(target.position);
        }

        if (Distance <= agent.stoppingDistance) 
        {
            //Attack target 
            FaceTarget();
        }
    }
    //This is about facing the target(player)
    void FaceTarget () 
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * 5f);
    }

    //This is about the lookRadius
    void OnGizmosSleceted ()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius );
 
    }
}
