using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour {

    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject run;
    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    void Start()    {
        // знаходить об'єкт Run
        run = GameObject.FindGameObjectWithTag("Run");
        // запускає таймер
        StartCoroutine(Inst1());
        StartCoroutine(Inst2());
    }

    IEnumerator Inst1()    {
        //чекає 0.2 с
        yield return new WaitForSeconds(2);
        //створює хмару  
        GameObject ob1 = Instantiate(cloud1, gameObject.transform.position, Quaternion.identity) as GameObject;
        Repeat();
    }
    IEnumerator Inst2()
    {
        //чекає 0.3 с
        yield return new WaitForSeconds(3);
        //створює хмару  
        GameObject ob2 = Instantiate(cloud2, gameObject.transform.position, Quaternion.identity) as GameObject;
        Repeat();
    }

    void FixedUpdate()    {
        //орієнтується на Run
        float posX = Mathf.SmoothDamp(transform.position.x, run.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, run.transform.position.y, ref velocity.y, smoothTimeY);
        //зміщується у випадкову сторону від Run 
        transform.position = new Vector3(posX + Random.Range(-15, 15), posY + Random.Range(-15, 15), transform.position.z);
    }
    //перезапускає таймер
    void Repeat()    {
        StartCoroutine(Inst1());
        StartCoroutine(Inst2());
    }
}
