using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using System.Collections;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour {

    //466x291
    public static GameManager ins;
    public GameObject enemyPreb;

    public float maxX;
    public float minX;
    public float topY ;
    public float randomInterval = 5;

    private float prevPosX;
    private float prevPosY;
    private float randomTimer = 0f;
    private bool startRandom = false;


    private void Awake() {
        ins = this;
    }

    // Use this for initialization
	void Start () {
	    prevPosY = topY;
        StartRandom();
	}
	
	// Update is called once per frame
	void Update () {
	    if (startRandom) {
	        if (randomTimer < randomInterval) {
	            randomTimer += Time.deltaTime;
	        }
	        else {
	            randomTimer = 0;
                RandomGenerateEnemy();
	        }
	    }
	}

    private void RandomGenerateEnemy() {
        if (enemyPreb != null) {
            prevPosX = Random.Range(minX, maxX);
            prevPosY = prevPosY + Random.Range(0, 5.5f);
            GameObject go = Instantiate(enemyPreb, new Vector3(prevPosX, prevPosY, 0), Quaternion.identity) as GameObject;
            go.GetComponent<Enemy>().scale = Random.Range(1.0f, 3.0f);
        }
        else {
            Debug.LogError("[GameManager] enemy prefab is null");
        }
    }

    public void StartRandom() {
        startRandom = true;
        randomTimer = 0;
    }

    public void StopRandom() {
        startRandom = false;
        randomTimer = 0;
    }
}
