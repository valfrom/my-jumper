using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public float speed = 50f;
	public float jumpPower =150f;

	public bool grounded;

	private Rigidbody2D rb2d;
	void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D > ();
	}
	void Update()
	{
		float h = Input.GetAxis ("Horizontal");
		rb2d.AddForce ((Vector2.right * speed) * h);

		if (Input.GetButtonDown ("Jump")  ) {
			rb2d.AddForce (Vector2.up * jumpPower*10);  

			}
		}
}