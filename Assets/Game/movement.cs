using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public float speed = 150f; //швидкість руху Jumper
	private Rigidbody2D rb2d;  

	public GameObject jumper;
	public Collider2D col;

	void Start() {
		rb2d = gameObject.GetComponent<Rigidbody2D > ();
	}
		
	void Update() {
		float h = Input.GetAxis ("Horizontal");
		rb2d.AddForce ((Vector2.right * speed) * h*3); //рухає вліво/вправо Jumper

		if (Input.GetButtonDown ("Jump") ) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, 15);  // стрибає, якщо нажати Space 
		}
	}

	void OnTriggerEnter2D (Collider2D col )	{
		rb2d.velocity = new Vector2 (rb2d.velocity.x, 15);  // стрибає, коли натикається на зірку/монетку
		Destroy (col.gameObject); //знищує предмет на який наткнувся Jumper
	}

}