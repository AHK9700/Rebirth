using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	
	public float speed = 3.0f;
	public Transform transform;
	

    // Update is called once per frame
    void FixedUpdate()
    {
		
		var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
        if(Input.GetKey(KeyCode.Mouse0))
		{
			transform.Translate(speed*Time.deltaTime, 0, 0);
		}
    }
}
