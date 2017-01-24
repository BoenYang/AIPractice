using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed = 2f;
    public int power = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    transform.Translate(Vector3.up * speed * Time.deltaTime);

	    if (transform.position.y >= 6.0f) {
	        Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "enemy") {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy) {
                enemy.Hurt(power);
            }
            else {
                Debug.LogError("enemy is null");
            }
            Destroy(gameObject);
        }
    }
}
