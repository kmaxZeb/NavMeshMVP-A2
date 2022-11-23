using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AreaMovementModifier : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField] float _speed = 8f;
    [SerializeField] float _grassSpeed = 2f;
    [SerializeField] float _lawnSpeed = 6f;
    [SerializeField] float _snowSpeed = 4f;

    float _agentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _agentSpeed = _speed;
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshHit hit;
        _agent.SamplePathPosition(-1, 0.0f, out hit);

        // init
        int areaMask = 0;
        int filtered = 0;
        _agentSpeed = _agent.speed;

        areaMask = 1 << NavMesh.GetAreaFromName("TallGrass");
        filtered = hit.mask & areaMask;    // & and; | or; ^ exclusive or
        // 0 means we didn't hit tall grass, anything else means we did
        if (filtered == 0)
        {   // Not on tall grass
        }
        else
        {   // on tall grass 
            _agentSpeed = _grassSpeed;
        }

        areaMask = 1 << NavMesh.GetAreaFromName("ShortGrass");
        filtered = hit.mask & areaMask; 
        if (filtered == 0)
        {   // Not on short grass
        }
        else
        {   // on grass 
            _agentSpeed = _lawnSpeed;
        }

        areaMask = 1 << NavMesh.GetAreaFromName("Ice");
        filtered = hit.mask & areaMask;
        if (filtered == 0)
        {   // Not on snow
        }
        else
        {   // on  snow
            _agentSpeed = _snowSpeed;
        }

        // Set Agent Speed
        _agent.speed = _agentSpeed;
    }
}
