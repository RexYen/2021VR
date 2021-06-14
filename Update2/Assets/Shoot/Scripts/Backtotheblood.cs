using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backtotheblood : MonoBehaviour
{
    public ProgressBar pb;
    private bool first_enter;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    float recover_range;
    float time_cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        first_enter = false;
        InvokeRepeating("OnGetEnemy", 2.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        time_cnt += Time.deltaTime;
        //OnGetEnemy(enemy.transform, 1.0f);
        //OnGetEnemy(enemy.transform, 0.5f);
        //OnGetEnemy(enemy.transform, 0.3f);
    }

    //public void OnGetEnemy(Transform enemy, float radius)
    public void OnGetEnemy()
    {
        //Debug.Log(time_cnt);
        //球形射線檢測,得到主角半徑2米範圍內所有的物件
        //Collider[] cols = Physics.OverlapSphere(enemy.position, radius);
        //判斷檢測到的物件中有沒有Enemy
        /*
        if (cols.Length > 0)
            for (int i = 0; i < cols.Length; i++)
                //判斷是否是怪物
                if (cols[i].tag.Equals("Enemy"))
                {
                    Debug.Log("Yes");
                    Debug.Log(radius);                    
                    pb.BarValue +=15;
                }
        */
        float dist = Vector3.Distance(enemy.transform.position, transform.position);
        Debug.Log(dist);
        if(dist < recover_range)
        {
            
            Debug.Log(dist);
            pb.BarValue += 40;
        }

    }
}
