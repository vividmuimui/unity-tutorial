using UnityEngine;
using System.Collections;

public class ProjectileFollowNew : MonoBehaviour {

	public Transform projectile;        // The transform of the projectile to follow.
	public Transform farLeft;           // The transform representing the left bound of the camera's position.
	public Transform farRight;          // The transform representing the right bound of the camera's position.

	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.x = projectile.position.x;
		newPosition.x = Mathf.Clamp(newPosition.x, farLeft.position.x, farRight.position.x);
		transform.position = newPosition;
	}
}
