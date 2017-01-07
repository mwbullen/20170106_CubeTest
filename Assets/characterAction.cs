using UnityEngine;
using System.Collections;

public class characterAction : MonoBehaviour {

	public float linkDistanceLimit = 1000f;
	public GameObject aimObject;

	public GameObject gameControl;

	public GameObject currentNode;
	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameControl");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//Debug.Log ("click");

			//attemptLinkNode ();
			linkNodes();
		}

	}

	void linkNodes() {
		/*if aimed at available node, 
		get current node
		get closest access point on current node
		create bridge to target node
		*/

		GameObject hitObject = getAimTarget ();

		if (hitObject != null && hitObject.tag == "AccessPoint") {
			//Debug.Log (getCurrentNode ().tag);

			if (getCurrentNode() != null) {
				currentNode = getCurrentNode().transform.parent.gameObject;
			}
			//currentNode = getCurrentNode ();

			GameObject closestAccessPoint = currentNode.GetComponent<accessPointManagement> ().getClosestAccessPoint (hitObject.transform.position);

			if (closestAccessPoint != null) {
				//create bridge
				gameControl.GetComponent<bridgeControl>().createBridge(hitObject, closestAccessPoint);

			}
		}
	}



	GameObject getCurrentNode() {
		RaycastHit r;

		Vector3 sourcePosition = transform.position;
		Ray aimRay = new Ray (sourcePosition, Vector3.down);

		//Debug.DrawRay (aimRay.origin, aimRay.direction * linkDistanceLimit);

		if (Physics.Raycast(aimRay, out r, 10)) {
			//Debug.Log (r.collider.gameObject.tag);
			//Debug.Log("distance:  " + Vector3.Distance(transform.position, r.collider.gameObject.transform.position));

			if (r.collider.gameObject.tag == "Node") {
				return r.collider.gameObject;
			}
		}

		return null;
	}

	GameObject getAimTarget() {
		RaycastHit r;

		Vector3 sourcePosition = aimObject.transform.position;

		Ray aimRay = new Ray (sourcePosition, Camera.main.transform.forward);

		Debug.DrawRay (aimRay.origin, aimRay.direction * linkDistanceLimit);

		if (Physics.Raycast(aimRay, out r, linkDistanceLimit)) {
			//Debug.Log (r.collider.gameObject.tag);
			//Debug.Log("distance:  " + Vector3.Distance(transform.position, r.collider.gameObject.transform.position));

			return r.collider.gameObject;
		}

		return null;
	}

	void attemptLinkNode() {
		GameObject hitObject = getAimTarget ();

		if (hitObject != null &&  hitObject.tag == "Node") {
			gameObject.GetComponent<linkMovement> ().movetoNode (transform.position, hitObject.transform.position + new Vector3(0,2,0));
		}

	}
}
