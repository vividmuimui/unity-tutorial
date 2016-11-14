using UnityEngine;
using System.Collections;

public class TargetDamageNew : MonoBehaviour {
	public int hitPoints = 2;
	public Sprite damageSprite;
	public float damageImpactSpeed;

	private int currentHitPoints;
	private float damageImpactSpeedSqr;
	private SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = GetComponent <SpriteRenderer>();
		currentHitPoints = hitPoints;
		damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.tag != "Damager")
		  return;
		if (other.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr)
		  return;

		spriteRenderer.sprite = damageSprite;
		currentHitPoints--;

		if (currentHitPoints <= 0)
		  Kill();		
	}

	void Kill()
	{
		spriteRenderer.enabled = false;
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Rigidbody2D>().isKinematic = true;
		GetComponent<ParticleSystem>().Play();
	}
}
