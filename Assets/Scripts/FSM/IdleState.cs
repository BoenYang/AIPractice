using UnityEngine;
using System.Collections;

public class IdleState : FSMState{

    private float reactionTime = 0.5f;
    private float reactionTimer = 0f;


    public IdleState(FSMAIController.State state, AIController controller)
        : base(state,controller) {
    }

    public override void Enter(){
        base.Enter();
        hero.StopMove();
        reactionTime = 0.5f + Random.Range(0, 0.5f);
        reactionTimer = 0f;
    }

    public override void Update(){
        reactionTimer += Time.deltaTime;
    }

    public override FSMAIController.State CheckTransitions() {
        if (controller.nearestEnemy != null && reactionTimer > reactionTime){
            return FSMAIController.State.Approach;
        }
        return FSMAIController.State.Idle;
    }

    public override void Exit(){
       
    }
}
