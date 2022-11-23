using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToObject : MonoBehaviour
{
    [SerializeField] private List<Transform> _capsule;
    [SerializeField] private List<Transform> _cylinder;

    int _index_cap = 0, _index_cap_max = 0;
    int _index_cyl = 0, _index_cyl_max = 0;

    private NavMeshAgent _agent;

    [SerializeField] private GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_capsule != null && _cylinder != null)
        {   _index_cap_max = _capsule.Count -1;
            _index_cyl_max = _cylinder.Count -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_index_cap_max > 0)
        {
            // Target Capsules
            if (_index_cap <= _index_cap_max)
            {   _agent.destination = _capsule[_index_cap].position;
                if(Vector3.Distance(transform.position, _capsule[_index_cap].position) < 1f )
                {
                    // Found Capsule
                    _capsule[_index_cap].gameObject.SetActive(false);
                    _index_cap++;
    
                    if(_index_cap > _index_cap_max)
                    {   
                        // Open door
                        door.SetActive(false);
                    }
                }
            }
            else if (_index_cyl <= _index_cyl_max)
            {
                // Search for next cylinder
                _agent.destination = _cylinder[_index_cyl].position;
                if(Vector3.Distance(transform.position, _cylinder[_index_cyl].position ) < 1f )
                {
                    // Found Cylinder
                    _cylinder[_index_cyl].gameObject.SetActive(false);
                    _index_cyl++;

                    if(_index_cyl > _index_cyl_max)
                    {   
                        // Close door
                        door.SetActive(true);
                    }
                }
            }
        }
    }
}
