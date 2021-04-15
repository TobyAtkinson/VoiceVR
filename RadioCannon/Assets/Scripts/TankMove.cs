using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankMove : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    private GameObject rallyPoint;

    [SerializeField]
    private GameObject destroyedTank;

    public bool target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {

    }


    void Update()
    {
        agent.SetDestination(rallyPoint.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Explosion"))
        {
            Instantiate(destroyedTank, this.gameObject.transform.position, Quaternion.identity);
            if (target == true)
            {
                this.transform.root.GetComponent<VoiceMovement>().TankDown();
            }

            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Line"))
        {
            this.transform.root.GetComponent<VoiceMovement>().TankReachedLine();
        }
    }

}
