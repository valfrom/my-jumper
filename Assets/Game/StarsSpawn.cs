using UnityEngine;
using System.Collections;

public class StarsSpawn : MonoBehaviour {

	public GameObject star;
	public GameObject run;
	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	void Start() {
        // знаходить об'єкт Run
        run = GameObject.FindGameObjectWithTag("Run");
        // запускає таймер
        StartCoroutine(Inst ()); 
	}

	IEnumerator Inst ()	{
        //чекає 2 секунди
        yield return new WaitForSeconds (2); 
        //створює зірку  
		GameObject ob = Instantiate (star, gameObject.transform.position, Quaternion.identity) as GameObject;  
		Repeat ();
	}

    void FixedUpdate(){
		//орієнтується на Run
		float posX = Mathf.SmoothDamp (transform.position.x, run.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, run.transform.position.y, ref velocity.y, smoothTimeY);
        //зміщується у випадкову сторону від Run 
		transform.position = new Vector3 (posX + Random.Range(-5, 5), posY + Random.Range(-5, 5), transform.position.z); 
	}
	//перезапускає таймер
	void Repeat()	{
		StartCoroutine (Inst ()); 
	}
		

}
