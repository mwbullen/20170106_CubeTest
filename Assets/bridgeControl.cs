using UnityEngine;
using System.Collections;

public class bridgeControl : MonoBehaviour {
	public GameObject defaultBridgePrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void createBridge(GameObject source, GameObject target) {
		GameObject newBridge = GameObject.Instantiate (defaultBridgePrefab);

		//newBridge.transform.position = (source.transform.position - target.transform.position) / 2;
		newBridge.transform.position = Vector3.Lerp(source.transform.position, target.transform.position, .5f);

		newBridge.transform.localScale = new Vector3 (1, 1,Vector3.Distance (source.transform.position, target.transform.position));

		newBridge.transform.LookAt (source.transform.position);
	}
}
