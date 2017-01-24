using UnityEngine;
using System.Collections;

public class FSMState {

    protected FSMAIController controller;
    protected Hero hero;
    public FSMAIController.State state;

    public FSMState(FSMAIController.State state,AIController controller) {
        this.controller = controller as FSMAIController;
        this.hero = this.controller.hero;
        this.state = state;
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Update() { }

    public virtual void Init() { }

    public virtual FSMAIController.State CheckTransitions() {  return 0;}

}
