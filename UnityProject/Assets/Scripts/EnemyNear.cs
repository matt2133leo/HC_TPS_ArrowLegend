using UnityEngine;

public class EnemyNear : Enemy
{
    public override void Move()
    {
        agent.SetDestination(player.position);
        ani.SetBool("跑步開關", true);
    }
}

