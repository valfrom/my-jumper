using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    //швидкість руху Jumper
    public float speed = 150f; 
	private Rigidbody2D rb2d;  

	public GameObject jumper;
	public Collider2D col;

	void Start() {
		rb2d = gameObject.GetComponent<Rigidbody2D > ();
	}
		
	void Update() {
		float h = Input.GetAxis ("Horizontal");
        //рухає вліво/вправо Jumper
        rb2d.AddForce ((Vector2.right * speed) * h*3); 

		if (Input.GetButtonDown ("Jump") ) {
            // стрибає, якщо нажати Space
            rb2d.velocity = new Vector2 (rb2d.velocity.x, 15);   
		}
	}

	void OnTriggerEnter2D (Collider2D col )	{
        // стрибає, коли натикається на зірку/монетку
        rb2d.velocity = new Vector2 (rb2d.velocity.x, 15);
        //знищує предмет на який наткнувся Jumper
        Destroy(col.gameObject); 
	}

}