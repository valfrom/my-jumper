using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public GameObject bg;
    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    void Start () {
        // запускає таймер
        StartCoroutine(Inst());
    }
    IEnumerator Inst()
    {
        //чекає 2 секунди
        yield return new WaitForSeconds(2);
        //створює фон  
        GameObject ob = Instantiate(bg, gameObject.transform.position, Quaternion.identity) as GameObject;
        Repeat();
    }
    void Repeat() {
        StartCoroutine(Inst());
    }
}
