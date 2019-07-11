using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour {

    public NavMeshAgent agent;
    public Camera cam;
    public Animator anim;
    public Interactable focus;
    public LayerMask layerMask;

    bool hasInteracted = false;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if(focus != null)
        {
            if (Vector3.Distance(transform.position, focus.transform.position) < focus.radius - focus.stoppingoffset && !hasInteracted)
            {
                focus.Interact();
                hasInteracted = true;

                Vector3 lookAt = new Vector3(focus.transform.position.x - transform.position.x, 0, focus.transform.position.z - transform.position.z);
                transform.forward = lookAt;
            }
        }
        
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit,100 ,layerMask))
            {
                Defocus();
                agent.SetDestination(hit.point);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Interactable")
            {
                SetFocus(hit.collider.GetComponent<Interactable>());
            }
        }
        var speedPercent = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("Speed", speedPercent);
    }

    void SetFocus(Interactable newFocus)
    {
        agent.stoppingDistance = newFocus.radius;
        focus = newFocus;
        agent.SetDestination(focus.transform.position);
        hasInteracted = false;

    }

    void Defocus()
    {
        focus = null;
        agent.stoppingDistance = 0;
        hasInteracted = false;
    }
}
