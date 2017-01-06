using UnityEngine;
using System.Collections;

public class characterAction : MonoBehaviour {

	public float linkDistanceLimit = 1000f;
	public GameObject aimObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//Debug.Log ("click");

			attemptLinkNode ();
		}

	}

	void attemptLinkNode() {

		RaycastHit r;

		Vector3 sourcePosition = aimObject.transform.position;

		Ray aimRay = new Ray (sourcePosition, Camera.main.transform.forward);

		Debug.DrawRay (aimRay.origin, aimRay.direction * linkDistanceLimit);

		if (Physics.Raycast(aimRay, out r, linkDistanceLimit)) {
			//Debug.Log (r.collider.gameObject.tag);
			//Debug.Log("distance:  " + Vector3.Distance(transform.position, r.collider.gameObject.transform.position));

			GameObject hitObject = r.collider.gameObject;

			if (hitObject.tag == "Node") {
				gameObject.GetComponent<linkMovement> ().movetoNode (transform.position, hitObject.transform.position + new Vector3(0,2,0));
			}
		}
	}
}
