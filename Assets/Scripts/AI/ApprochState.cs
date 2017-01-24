using System.Security.AccessControl;
using UnityEngine;
using System.Collections;

public class ApproachState : FSMState {

    public ApproachState(FSMAIController.State state, AIController controller)
        : base(state,controller) {
    }

    public override void Enter() {
        Debug.Log("Approach Enter");
    }

    public override void Exit() {
    }

    public override void Update(){
        Enemy nearsetEnemy = controller.nearestEnemy;
        if (nearsetEnemy != null){
            float distanceX = nearsetEnemy.transform.position.x - hero.transform.position.x;

            if (distanceX < 0){
                hero.MoveLeft();
            }

            if (distanceX > 0){
                hero.MoveRight();
            }
        }
    }

    public override void Init() {
    }

    public override FSMAIController.State CheckTransitions() {
        if (controller.willCollide) {
            return FSMAIController.State.Evade;
        }
        if (hero.EnemyInAttackRange(controller.nearestEnemy)){
            return FSMAIController.State.Attack;
        }
        return FSMAIController.State.Approach;
    }
}
