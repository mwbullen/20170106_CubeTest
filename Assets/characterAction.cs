using UnityEngine;
using System.Collections;

public class characterAction : MonoBehaviour {

	public float linkDistanceLimit = 1000f;

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

		Vector3 sourcePosition = Camera.main.transform.position;

		Debug.DrawRay (sourcePosition, transform.forward * linkDistanceLimit);

		if (Physics.Raycast(new Ray(transform.position, transform.forward), out r, linkDistanceLimit)) {
			Debug.Log (r.collider.gameObject.tag);
			Debug.Log("distance:  " + Vector3.Distance(transform.position, r.collider.gameObject.transform.position));
		}
	}
}
