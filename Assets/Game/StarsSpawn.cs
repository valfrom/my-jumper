using UnityEngine;
using System.Collections;

public class StarsSpawn : MonoBehaviour {

	public GameObject star;
	public GameObject jumper;
	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	void Start() {
        // знаходить Run
        jumper = GameObject.FindGameObjectWithTag("Run");
        // запускає таймер
		StartCoroutine (Inst ()); 
	}

	IEnumerator Inst ()	{
        //чекає 2 секунди
        yield return new WaitForSeconds (2);
        //створює зірку
        GameObject ob = Instantiate (star, gameObject.transform.position, Quaternion.identity) as GameObject;   
		Repeat ();
	}
    void Update()  {
        //піднімає камеру повільно вверх
        GetComponent<Camera>().transform.position += GetComponent<Camera>().transform.up * 5f * Time.deltaTime;
    }
    void FixedUpdate() {
		//орієнтується на Jumper
		float posX = Mathf.SmoothDamp (transform.position.x, jumper.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, jumper.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX + Random.Range(-5, 5), posY + Random.Range(-5, 5), transform.position.z); 
	}
	//перезапускає таймер
	void Repeat()	{
		StartCoroutine (Inst ()); 
	}	
}
