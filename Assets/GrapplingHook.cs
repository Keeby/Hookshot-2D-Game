using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {

    public LineRenderer line;
    SpringJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask mask;
    public float step = 0.2f;

	// Use this for initialization
	void Start () {
        joint = GetComponent<SpringJoint2D>();
        joint.enabled = false;
        line.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (joint.distance > 2f)
        {
            joint.distance -= step;
        }

		if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;
            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);
            
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                joint.enabled = true;
                Vector2 connectPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                connectPoint.x = connectPoint.x / hit.collider.transform.localScale.x;
                connectPoint.y = connectPoint.y / hit.collider.transform.localScale.y;
                joint.connectedAnchor = connectPoint;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);


            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            line.SetPosition(0, transform.position);
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            joint.enabled = false;
            line.enabled = false;
        }
	}
}
