using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.AI;



public class Enemy_Liminal : MonoBehaviour
{
    //public _Player_Health _HS;
    private Enemy_see CanSeePlayS;
    
    public bool isAttack = false; // разрешение на атаку

    NavMeshAgent m_agent;
    public Transform player;
    public Transform[] waypoint;
    public int c_patch;
    public enum ai_state { Patrul, Stay, Chase };
    public ai_state ai_enum;

    private Animator _animator;

    public bool anim_is_good;

    private void Awake()
    {
        CanSeePlayS = GetComponent<Enemy_see>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if ((ai_enum == ai_state.Patrul) && (CanSeePlayS.canSeePlayer == false))
        {
            _animator.SetBool("Chase", false);
            _animator.SetBool("Patrul", true);
            m_agent.SetDestination(waypoint[c_patch].transform.position);
            float patch_dist = Vector3.Distance(waypoint[c_patch].transform.position, gameObject.transform.position);
            if (patch_dist < 2)
            {
                c_patch++;
                c_patch = c_patch % waypoint.Length;
            }
            _animator.SetBool("Attack", false);
            anim_is_good = false;
            isAttack = false; 
        }
        if (ai_enum == ai_state.Stay && (isAttack == false))
        {
            _animator.SetBool("Patrul", false);
            _animator.SetBool("Chase", false);
            _animator.SetBool("Attack", false); 
        }
        if (ai_enum == ai_state.Chase)
        {

            float dist_player = Vector3.Distance(player.transform.position, gameObject.transform.position);
            m_agent.SetDestination(player.transform.position);
            if (dist_player < 1.3 && isAttack == true) 
            {
                if(this._animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    //Debug.Log("True");
                    anim_is_good = true;
                }
                else{anim_is_good = false;}

                    //_HS.Health -= 5f;
                _animator.SetBool("Patrul", false);
                _animator.SetBool("Attack", true);
                //gameObject.GetComponent<Animator>().SetBool("Chase", false);
            }
            else
            {
                //m_agent.SetDestination(player.transform.position);
                _animator.SetBool("Patrul", false);
                _animator.SetBool("Chase", true);
                _animator.SetBool("Attack", false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && CanSeePlayS.canSeePlayer == true)
        {
            isAttack = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && CanSeePlayS.canSeePlayer == false)
        {
            isAttack = false;
        }
    }
}


