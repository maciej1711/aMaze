using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
		public GameObject target;
		public float damping = 1;
	    public float rotateSpeed = 5;
	    public float turningSpeed = 100;
		Vector3 offset;
		
		void Start() {
			offset = target.transform.position - transform.position;
		}
		
		void LateUpdate() {
			float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
			float currentAngle = transform.eulerAngles.z;
			float desiredAngle = transform.eulerAngles.z;
			transform.Rotate(0, horizontal, 0);
				
			Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
			transform.position = target.transform.position - (rotation * offset);
			
			transform.LookAt(target.transform);
		}
}