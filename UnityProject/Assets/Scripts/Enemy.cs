using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public EnemyData data;

    public NavMeshAgent agent;   //導覽代理器
    public Transform player;     //玩家變形
    public Animator ani;
    private void Start()
    {
        //先取得元件
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = data.speed;
        player = GameObject.Find("SciFiWarriorFreeMesh").transform;
    }

    private void Update()
    {
        Move();
    }

    private void Attack()
    {
        

    }

    public virtual void Move()
    {


    }

    private void Hit()
    {


    }

    private void Dead()
    {



    }


}
