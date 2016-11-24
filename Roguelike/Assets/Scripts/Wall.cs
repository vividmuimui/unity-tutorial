using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
	public Sprite dmgSprite;
	public int hp = 4;
	public AudioClip chopSound1;
	public AudioClip chopSound2;

	SpriteRenderer spriteRenderer;

	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void DamageWall(int loss)
	{
		spriteRenderer.sprite = dmgSprite;
		hp -= loss;
		SoundManager.instance.RandomizeSfx(chopSound1, chopSound2);
		if(hp <= 0)
			gameObject.SetActive(false);
	}
}
