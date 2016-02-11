using UnityEngine;
using System.Collections;
//тут все аналогічно до StarSpawn
public class CoinsSpawn : MonoBehaviour {

	public GameObject coin;

	private Vector2 velocity;
    private GameObject cam;
    public float smoothTimeY;
	public float smoothTimeX;

	void Start() {
        cam = GameObject.FindGameObjectWithTag("Run");
		StartCoroutine (Inst ());
	}

	IEnumerator Inst () {
		yield return new WaitForSeconds (0.3f);
		GameObject ob = Instantiate (coin, gameObject.transform.position, Quaternion.identity) as GameObject;  
		Repeat ();
	}
		
	void FixedUpdate(){
        
        float posX = Mathf.SmoothDamp(transform.position.x, cam.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, cam.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX + Random.Range(-5, 5), posY+20 , transform.position.z);
    }

	void Repeat() {
		StartCoroutine (Inst ());
	}
}
