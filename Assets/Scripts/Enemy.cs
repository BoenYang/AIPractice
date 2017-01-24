using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public static List<Enemy> enemies = new List<Enemy>();
    
    public float moveSpeed;
    public float scale;
    public int maxhp;
    private int hp;

    private void Awake() {
     
    }

    void Start () {
        maxhp = (int)(maxhp*scale);
        hp = maxhp;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(scale, scale, scale);
	    transform.Translate(Vector3.down*moveSpeed*Time.deltaTime);

	}

    public void Hurt(int power) {
        hp -= power;
        if (hp <= 0){
            enemies.Remove(this);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "entertrigger") {
            enemies.Add(this);
        }
        if (other.tag == "exittrigger") {
            enemies.Remove(this);
            Destroy(gameObject);
        }
    }
}
