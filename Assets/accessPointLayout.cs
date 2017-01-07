using UnityEngine;
using System.Collections;

public class accessPointLayout : MonoBehaviour {
	public GameObject accessPointPrefab;
	public GameObject accessPointParent;

	public int numberAccessPoints = 4;

	// Use this for initialization
	void Start () {
		initAccessPoints ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void initAccessPoints() {
		for (int i = 0; i < numberAccessPoints; i++) {
			GameObject newAccessPoint = GameObject.Instantiate (accessPointPrefab);

			newAccessPoint.transform.parent = accessPointParent.transform;

			newAccessPoint.transform.position = newAccessPoint.transform.parent.position + new Vector3 (3.5f, 0, 3.5f);
		}
	}
}
