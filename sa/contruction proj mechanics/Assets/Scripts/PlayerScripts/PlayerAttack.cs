using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool ispaused;
    private float timebtwAttack;
    public float startTimebtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask BoxesToDamage;
    public int damage;


    // Update is called once per frame
    void Update()
    {
        if (timebtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.J))
            {
                Collider2D[] boxesToBreak = Physics2D.OverlapCircleAll(attackPos.position, attackRange, BoxesToDamage);
                for (int i = 0; i < boxesToBreak.Length ; i++)
                {
                    boxesToBreak[i].GetComponent<WoodBoxesScript>().TakeDamage(damage);
                }
            }

            timebtwAttack = startTimebtwAttack;
        }
        else
        {
            timebtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
