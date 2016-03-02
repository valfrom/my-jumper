using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour {

    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject r;
    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    void Start()    {
        // знаходить Run
        r = GameObject.FindGameObjectWithTag("Run");
        // запускає таймери
        StartCoroutine(Inst1());
        StartCoroutine(Inst2()); 
    }

    void FixedUpdate()    {     
        //орієнтується на Run
        float posX = Mathf.SmoothDamp(transform.position.x, r.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, r.transform.position.y, ref velocity.y, smoothTimeY);
        
        transform.position = new Vector3(posX + Random.Range(-10, 10), posY +20+ Random.Range(-5, 5), transform.position.z); 
    }

    IEnumerator Inst2()    {
        //чекає 1 секунду
        yield return new WaitForSeconds(1); 
        GameObject ob = Instantiate(cloud2, gameObject.transform.position, Quaternion.identity) as GameObject;   
        Repeat();
    }
    IEnumerator Inst1() {
        //чекає 2,5 секунди
        yield return new WaitForSeconds(2.5f); 
        GameObject ob = Instantiate(cloud1, gameObject.transform.position, Quaternion.identity) as GameObject;   
        Repeat();
    }
    //перезапускає таймери
    void Repeat() {
        StartCoroutine(Inst1());
        StartCoroutine(Inst2());
    }
}
