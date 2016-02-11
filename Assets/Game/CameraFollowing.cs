using UnityEngine;
using System.Collections;

public class CameraFollowing : MonoBehaviour {

	private GameObject cam;
	private int speed=2;

	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;
	public GameObject jumper;

	void Start () {
		cam = (GameObject)this.gameObject; //знаходить камеру
		jumper = GameObject.FindGameObjectWithTag ("Jumper");  //знаходить  Jumper
	}

	void Update () {
		//піднімає камеру повільно вверх
		GetComponent<Camera>().transform.position += GetComponent<Camera>().transform.up * speed * Time.deltaTime;
	}

	void FixedUpdate(){
		//камера орієнтується на Jumper, показуючи його 
		float posX = Mathf.SmoothDamp (transform.position.x, jumper.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y,jumper.transform.position.y, ref velocity .y, smoothTimeY );
			
		transform.position = new Vector3 (posX, posY, transform.position.z);
	}
}
