 using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    public static Hero ins;
    public GameObject bullet;

    public float moveSpeed = 1f;
    public int fireRate = 1;
    public bool ai = false;
    public float warningRange = 1f;


    private bool canFire = false;
    private bool firing = false;
    private float fireTimer = 0;
    private float fireInterval;

    private bool moveLeft = false;
    private bool moveRight = false;
    private bool moveUp = false;
    private bool moveDown = false;

    private FSMAIController aiController;

    private void Awake() {
        ins = this;
        aiController = new FSMAIController(this);
    }

    private void Start() {
        fireInterval = 1.0f/(float) fireRate;
        canFire = true;
    }

    // Update is called once per frame
	void Update () {

	    if (ai){
	        aiController.Update();
        }

	    if (firing) {
            if (fireTimer < fireInterval)
            {
                fireTimer += Time.deltaTime;
                canFire = false;
            }
            else
            {
                canFire = true;
                fireTimer = 0;
                firing = false;
            }
        }

	    if (moveLeft) {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);    
        }

	    if (moveRight) {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);    
        }
	}

    public void Fire() {
        firing = true;
        if (canFire) {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    public void StopFire(){
        firing = false;
    }

    public void MoveLeft() {
        moveLeft = true;
        moveRight = false;
        moveDown = false;
        moveUp = false;
    }

    public void MoveRight() {
        moveLeft = false;
        moveRight = true;
        moveUp = false;
        moveDown = false;
    }

    public void MoveUp() {
        moveLeft = false;
        moveRight = false;
        moveUp = true;
        moveDown = false;
    }

    public void MoveDown() {
        moveLeft = false;
        moveRight = false;
        moveUp = false;
        moveDown = true;
    }

    public void StopMove() {
        moveRight = moveLeft = moveUp = moveDown = false;
    }

    public bool EnemyInAttackRange(Enemy enemy){
        float enemyHalfSize = enemy.scale/2.0f;

        float x = transform.position.x;

        if ( x > (enemy.transform.position.x - enemyHalfSize) &&  x < (enemy.transform.position.x + enemyHalfSize))
        {
            return true;
        }
        return false;
    }

    public void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,warningRange);
    }

    public bool willCollide(Enemy enemy) {
        float distance = Vector3.Distance(transform.position, enemy.transform.position);
        if ((distance - warningRange - enemy.scale) <= 0 ) {
            return true;
        }
        return false;
    }
}
