using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected enum enemyFSM
    {
        Wander,
        Persue,
        Attack,
        Flee
    }
    protected enemyFSM m_state = enemyFSM.Wander;
    protected float m_Health = 100.0f;

    // settings
    [Header("Settings")]
    [Tooltip("The player we are following.")]
    [SerializeField] protected Transform m_player;
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemyState(m_player);
        StepEnemy(m_player, m_state, Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.L))
        {
            m_Health = 10.0f;
        }
        
    }
    protected abstract void UpdateEnemyState(Transform player);

    private void StepEnemy(Transform player, enemyFSM state, float dt)
    {
        float fleeSpeed = 10.0f;
        float wanderSpeed = 1.0f;
        float attackSpeed = 3.0f;

        switch(state)
        {
            case enemyFSM.Wander:
            Vector3 randomPos = new Vector3(Random.Range(0f, 100f), 0f, Random.Range(0f, 100.0f));
            transform.rotation = Quaternion.LookRotation(transform.position - randomPos);
            transform.Translate(Vector3.forward * wanderSpeed * dt);
            Debug.DrawRay(transform.position, transform.forward * wanderSpeed, Color.red);
            break;

            case enemyFSM.Persue:
            transform.rotation = Quaternion.LookRotation(player.position - transform.position);
            transform.Translate(Vector3.forward * attackSpeed * dt);
            Debug.DrawRay(transform.position, transform.forward * attackSpeed, Color.red);
            break;

            case enemyFSM.Attack:
            // take the L
            break;
            case enemyFSM.Flee:
            transform.rotation = Quaternion.LookRotation(transform.position - player.position);
            transform.Translate(Vector3.forward * fleeSpeed * dt);
            Debug.DrawRay(transform.position, transform.forward * fleeSpeed, Color.red);
            break;
        }
    }
    private void OnDrawGizmos()
    {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.black;

        UnityEditor.Handles.BeginGUI();
        UnityEditor.Handles.color = Color.blue;
        UnityEditor.Handles.Label(transform.position, $"{name} ({m_state}, {m_Health})", style);
        UnityEditor.Handles.EndGUI();
    }
}
