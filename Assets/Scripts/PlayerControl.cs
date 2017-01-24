using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	    if (Hero.ins.ai){
	        return;
        }

	    float dir = Input.GetAxis("Horizontal");

	    if (dir < 0) {
	        Hero.ins.MoveLeft();
        }

	    if (dir > 0) {
            Hero.ins.MoveRight();
        }

	    if (dir == 0) {
	        Hero.ins.StopMove();    
	    }

	    if (Input.GetButton("Jump")) {
            Hero.ins.Fire();
        }

	    if (Input.GetButtonUp("Jump")) {
	        
        }
	}

}
