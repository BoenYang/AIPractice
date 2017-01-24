using UnityEngine;

public class AttackState : FSMState{

    private Enemy attackTarget;

    public AttackState(FSMAIController.State state, AIController controller)
        : base(state,controller) {
    }

    public override void Enter(){
        Debug.Log("Attack enter");
        hero.StopMove();
        attackTarget = controller.nearestEnemy;
    }

    public override void Update() {
        hero.Fire();
    }

    public override FSMAIController.State CheckTransitions() {
        if (attackTarget == null){
            return FSMAIController.State.Idle;
        }

        if (controller.willCollide){
            return FSMAIController.State.Evade;
        }
        return FSMAIController.State.Attack;
    }

    public override void Exit() {
        hero.StopFire();
    }
}
