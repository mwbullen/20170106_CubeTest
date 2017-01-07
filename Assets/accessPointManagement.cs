using UnityEngine;
using System.Collections;

public class accessPointManagement : MonoBehaviour {
	public GameObject accessPointParent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject getClosestAccessPoint(Vector3 targetPosition) {
		float currentClosestDistance = Mathf.Infinity;
		GameObject currentClosestNode = null;

		//accessPointParent.transform.

		foreach (Transform accessPointTransform in accessPointParent.transform) {
		//foreach (GameObject accessPoint in accessPointParent.transform.
			Debug.Log("1");
			float distance = Vector3.Distance (targetPosition, accessPointTransform.position);

			if (distance < currentClosestDistance) {
				currentClosestDistance = distance;
				currentClosestNode = accessPointTransform.gameObject;
			}
		}

		return currentClosestNode;
	}
}
