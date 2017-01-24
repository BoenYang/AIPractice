using UnityEngine;
using System.Collections;

public class EvadeState : FSMState {

    public EvadeState(FSMAIController.State state, AIController controller)
        : base(state,controller) {
    }

    public override void Enter() {
        Debug.Log("Evade enter");
    }

    public override void Exit() {
    }

    public override void Update() {
        Enemy nearestEnemy = controller.nearestEnemy;
        float dir = nearestEnemy.transform.position.x - hero.transform.position.x;
        if (dir < 0) {
            hero.MoveRight();
        }

        if (dir > 0) {
            hero.MoveLeft();
        }
    }

    public override void Init() {
    }

    public override FSMAIController.State CheckTransitions() {
        if (!controller.willCollide) {
            return FSMAIController.State.Idle;
        }
        return FSMAIController.State.Evade;
    }
}
