using UnityEngine;
using System.Collections;

public class NodeLayout : MonoBehaviour {
	public GameObject nodePrefab;
	public GameObject characterPrefab;
	public GameObject characterObject;

	public GameObject nodesParent;

	public int numberNodesStart;

	public float minX = 0;
	public float maxX = 300;
	public float minY = 0;
	public float maxY = 300;
	public float minZ = 0;
	public float maxZ = 300;

	// Use this for initialization
	void Start () {
		createNodes ();

		createCharacter ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void createCharacter() {
		//GameObject characterObject = GameObject.Instantiate (characterPrefab);

		GameObject[] nodes = GameObject.FindGameObjectsWithTag ("Node");

		GameObject randomNode = nodes [Random.Range (0, nodes.Length)];

		characterObject.transform.position = randomNode.transform.position;
	}

	void createNodes() {
		for (int i = 0; i < numberNodesStart; i++) {
			GameObject newNode = GameObject.Instantiate (nodePrefab);

			newNode.transform.position = getRandomVector ();
			newNode.transform.parent = nodesParent.transform;
		}
	}

	Vector3 getRandomVector() {
		float x = Random.Range (minX, maxX);
		float y = Random.Range (minY, maxY);
		float z = Random.Range (minZ, maxZ);

		return new Vector3 (x, y, z);
	}
}
