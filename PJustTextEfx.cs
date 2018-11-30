using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJustTextEfx : MonoBehaviour {
    public float speed = 5f;
    public float delta = 3f;

	void Start () {
		
	}

	void Update () {
        float y = transform.position.y + Mathf.PingPong(speed * Time.time, delta);
        Vector3 pos = new Vector3(transform.position.x, y, transform.position.z);
        transform.position = pos;
    }
}
