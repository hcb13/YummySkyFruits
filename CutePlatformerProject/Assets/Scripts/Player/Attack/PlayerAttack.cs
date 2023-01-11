using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Action OnAttack = delegate { };

    private bool isAttacking = false;

    private void Awake()
    {
        GetComponent<GetInput>().OnGetButtonDownAttack += Attack;
    }

    private void Attack(bool buttonDown)
    {
        if (buttonDown)
        {
            isAttacking = true;
            OnAttack?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAttacking)
        {
            Debug.Log("Attacking");
            if (collision.collider.CompareTag("HurtBox"))
            {
                Debug.Log("Found enemy");
                collision.collider.SendMessageUpwards("AddDamage");
            }
        }
    }
}
