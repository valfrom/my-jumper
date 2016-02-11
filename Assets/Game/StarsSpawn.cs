using UnityEngine;
using System.Collections;

public class StarsSpawn : MonoBehaviour {

	public GameObject star;
	public GameObject jumper;
	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	void Start() {
		jumper= GameObject.FindGameObjectWithTag("Jumper");// знаходить Jumper
		StartCoroutine (Inst ()); // запускає таймер
	}

	IEnumerator Inst ()	{
		yield return new WaitForSeconds (2); //чекає 2 секунди
		GameObject ob = Instantiate (star, gameObject.transform.position, Quaternion.identity) as GameObject; //створює зірку на  
		Repeat ();//викликає функцію Repeat
	}
		
	void FixedUpdate(){
		//орієнтується на Jumper
		float posX = Mathf.SmoothDamp (transform.position.x, jumper.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y,jumper.transform.position.y, ref velocity.y, smoothTimeY );

		transform.position = new Vector3 (posX, posY+20, transform.position.z); // зміщується на 20 вище по Y від Jumper
	}
	//перезапускає таймер
	void Repeat()	{
		StartCoroutine (Inst ()); 
	}
		

}
