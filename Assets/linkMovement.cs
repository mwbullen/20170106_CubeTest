using UnityEngine;
using System.Collections;

public class linkMovement : MonoBehaviour {

	public Vector3 startPosition;
	public Vector3 targetPosition;

	float moveStartTime;
	float totalMoveDistance;

	public bool moving = false;
	public float speed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			float distCovered = (Time.time - moveStartTime) * speed;
			float fracJourney = distCovered / totalMoveDistance;
			transform.position = Vector3.Lerp(startPosition,targetPosition, fracJourney);

			if (fracJourney  > .98f) {
				moving = false;
				Debug.Log ("move complete");
			}
		}
	}

	public void movetoNode(Vector3 newStartPosition, Vector3 newTargetPosition) {
		startPosition = newStartPosition;
		targetPosition = newTargetPosition;

		moveStartTime = Time.time;
		totalMoveDistance = Vector3.Distance (startPosition,targetPosition);

		moving = true;
	}

}
