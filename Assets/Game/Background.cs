using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;
    public GameObject bg;


    void Start() {
        //знаходить  Jumper
        bg = GameObject.FindGameObjectWithTag("Jumper");  
    }

    void FixedUpdate() {
        //камера орієнтується на Jumper, показуючи його 
        float posX = Mathf.SmoothDamp(transform.position.x, bg.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, bg.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
