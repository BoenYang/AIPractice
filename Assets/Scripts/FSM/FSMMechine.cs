using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using System.Collections;

public class FSMMechine {

    private Dictionary<FSMAIController.State, FSMState> stateDict = new Dictionary<FSMAIController.State, FSMState>(); 
    private FSMState currentState = null;
    private FSMState defaultState = null;
    private FSMState goalState = null;
    private FSMAIController.State dstState;
    private FSMAIController.State oldState;

    public FSMMechine(){
    }

    public virtual void UpdateMachine() {
        if (stateDict.Count == 0) {
            return;
        }

        if (currentState == null) {
            currentState = defaultState;
        }

        if (currentState == null) {
            return;
        }

        FSMAIController.State oldState = currentState.state;

        dstState = currentState.CheckTransitions();

        ChangeState(dstState);

        currentState.Update();
    }

    public void ChangeState(FSMAIController.State dstState) {
        if (dstState != oldState)
        {
            if (TransitionState(dstState)) {
                this.currentState.Exit();
                this.currentState = goalState;
                currentState.Enter();
            }
            else {
                Debug.LogError("Can not found state " + dstState);
            }
        }
    }

    public virtual void AddState(FSMState state) {
        stateDict.Add(state.state,state);
    }

    public virtual void SetDefaultState(FSMState state) {
        defaultState = state;
    }

    public virtual bool TransitionState(FSMAIController.State dstState){
        goalState = stateDict[dstState];
        if (goalState != null){
            return true;
        }
        else{
            return false;
        }
    }

    public virtual void Reset() {
        currentState = null;
    }
}
