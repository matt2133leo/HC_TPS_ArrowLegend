using UnityEngine;
using System.Collections;

public class EnemyNear : Enemy
{
    public override void Move()
    {
        agent.SetDestination(player.position);

        if (agent.remainingDistance <= data.stopDistance)
        {
            Wait();
        }
        else
        {
            agent.isStopped = false;
            ani.SetBool("跑步開關", true);
        }
    }
        //override : 複寫父類別有virtual 的方法
    public override void Wait()
    {
        // base.Wait(); //使用付類別方法內容

        agent.isStopped = true;         //代理器.是否停止 = 是
        agent.velocity = Vector3.zero;  //代理器.加速度 = 零
        ani.SetBool("跑步開關", false); //關閉跑步開關

        if(timer <= data.cd)            //如果 計時器 <= 冷卻時間
        {
            timer += Time.deltaTime;    //時間累加
            //print("時間:" + timer);
        }
        else
        {
            Attack();                   //否則 計時器 > 冷卻時間 攻擊
        }

    }    
    
    public override void Attack()
    {
        timer = 0;                      //計時器 歸零
        ani.SetTrigger("攻擊觸發");     //攻擊動畫
        StartCoroutine(DelayAttack());   //啟動協程
    }


    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(data.attackDelay);

        RaycastHit hit; // 射線碰撞資訊 - 存放射線碰到的內容

        // out 存放參數資訊
        //物理.射線碰撞(中心點,方向,長度)
        if (Physics.Raycast(transform.position + new Vector3(0,1,0), transform.forward,out hit, data.attackRange))
        {
            print("打到東西惹~" + hit.collider.gameObject);
            //取得玩家元件.受傷方法(怪物.攻擊力)
            hit.collider.GetComponent<Player>().Hit(data.atk);


        }
    }

    // Ctrl + MO 摺疊
    // Ctrl + ML 展開
    //事件：繪製圖示
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // 前方:transform.forward
        // 右方:transform.right
        // 上方:transform.up

        Gizmos.DrawRay(transform.position + new Vector3(0, 1, 0), transform.forward * data.attackRange);
    }
}

