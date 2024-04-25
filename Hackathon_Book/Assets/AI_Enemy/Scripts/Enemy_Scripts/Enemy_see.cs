using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.AI;

public class Enemy_see : MonoBehaviour
{
    public float radius;
    [Range(0, 360)] 
    public float angle;
    public GameObject player;
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    private Enemy_Liminal enemyLiminalScript;
    public bool canSeePlayer;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("player");
        enemyLiminalScript = GetComponent<Enemy_Liminal>();
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        while (true)
        {
            yield return wait;
            ViewCheck();
        }
    }

    void Update()
    {
        if (canSeePlayer)
        {
             enemyLiminalScript.ai_enum = Enemy_Liminal.ai_state.Chase;
            // Отключаем патрулирование, когда видим игрока
            //enemyLiminalScript.enabled = false;
        }
        else
        {
            if(enemyLiminalScript.isAttack == false) enemyLiminalScript.ai_enum = Enemy_Liminal.ai_state.Patrul;
            // Включаем патрулирование, когда игрок не виден
            //enemyLiminalScript.enabled = true;
        }
    }

    private void ViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < angle / 2f)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
                {
                    canSeePlayer = true;
                    // Запускаем корутину для возвращения к патрулированию
                    //StartCoroutine(ReturnToPatrolAfterDelay());
                }
                else{canSeePlayer = false;}
            }
            else{canSeePlayer = false;}
        }
        else{canSeePlayer = false;}
    }

    /*rivate IEnumerator ReturnToPatrolAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        canSeePlayer = false;
    }*/
}
