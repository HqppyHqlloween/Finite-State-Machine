using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    protected override void UpdateEnemyState(Transform player)
    {
        float distance = (transform.position - player.position).magnitude;

        switch(m_state)
        {
            case enemyFSM.Wander:
            if(distance < 10.0f)
            m_state = enemyFSM.Persue;
            break;

            case enemyFSM.Persue:
            if (distance < 5.0f)
            m_state = enemyFSM.Attack;
            else if (distance > 11.0f)
            m_state = enemyFSM.Wander;
            break;

            case enemyFSM.Attack:
            if(m_Health < 20.0f) 
            m_state = enemyFSM.Flee;
            else if (distance > 6.0f)
            m_state = enemyFSM.Persue;
            break;

            case enemyFSM.Flee:
            if(m_Health > 60.0f)
            m_state = enemyFSM.Wander;
            break;
        }
    }
}
