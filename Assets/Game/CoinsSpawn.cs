using UnityEngine;
using System.Collections;
//тут все аналогічно до StarSpawn
public class CoinsSpawn : MonoBehaviour {

	public GameObject coin;
	public GameObject jumper;
	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	void Start() {
		jumper = GameObject.FindGameObjectWithTag("Jumper")  ;
		StartCoroutine (Inst ());
	}

	IEnumerator Inst () {
		yield return new WaitForSeconds (0.3f);
		GameObject ob = Instantiate (coin, gameObject.transform.position, Quaternion.identity) as GameObject;  
		Repeat ();
	}
		
	void FixedUpdate(){
		float posX = Mathf.SmoothDamp (transform.position.x, jumper.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y,jumper.transform.position.y, ref velocity.y, smoothTimeY );

		transform.position = new Vector3 (posX+ Random.Range(-2,2), posY + 10 , transform.position.z);
	}

	void Repeat() {
		StartCoroutine (Inst ());
	}
}
