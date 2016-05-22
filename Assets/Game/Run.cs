using UnityEngine;
using System.Collections;

public class Run : MonoBehaviour {

    private float speed = 15f;
    private GameObject rn;

	void Start () {
        rn = GameObject.FindGameObjectWithTag("Run");
    }
	
	void Update () {
        rn.transform.position += rn.transform.up * speed * Time.deltaTime;
    }
}
