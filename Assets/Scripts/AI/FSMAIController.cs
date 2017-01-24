using System.Collections.Generic;
using UnityEngine;

public class FSMAIController : AIController {

    public Hero hero;
    public Enemy nearestEnemy = null;
    public bool willCollide = false;

    private FSMMechine fsmMechine;

    public enum State{
        Attack = 0,
        Idle = 1,
        Approach = 2,
        Evade = 3,
        None = -1,
    }

    public FSMAIController(Hero hero) {
        this.hero = hero;
        fsmMechine = new FSMMechine();
        AttackState attackState = new AttackState(State.Attack,this);
        ApproachState approachState = new ApproachState(State.Approach,this);
        IdleState idleState = new IdleState(State.Idle,this);
        EvadeState evadeState = new EvadeState(State.Evade,this);
        fsmMechine.AddState(attackState);
        fsmMechine.AddState(approachState);
        fsmMechine.AddState(idleState);
        fsmMechine.AddState(evadeState);
        fsmMechine.SetDefaultState(idleState);
    }

    public override void Update() {
        if (hero == null) {
            fsmMechine.Reset();
            return;
        }
        UpdatePreceptions();
        fsmMechine.UpdateMachine();
    }

    public override void UpdatePreceptions(){
        List<Enemy> enemies = Enemy.enemies;
        if (enemies.Count > 0){
            nearestEnemy = enemies[0];
            float minDistance = Vector3.Distance(nearestEnemy.transform.position, hero.transform.position);
            foreach (var enemy in enemies){
                if (Vector3.Distance(enemy.transform.position, hero.transform.position) <= minDistance){
                    nearestEnemy = enemy;
                }
            }

            willCollide = hero.willCollide(nearestEnemy);
        }
        else{
            nearestEnemy = null;
        }
    }

}
