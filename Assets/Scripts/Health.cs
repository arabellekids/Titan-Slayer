using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Health : MonoBehaviour {


    [SerializeField] int maxHp = 10;
    int currentHp;
    Animator anim;
    public enum DeathType
    {
        Disable,
        Destroy,
        Log_Message,
        Play_Anim
    }
    public DeathType onDeath;
    // Use this for initialization
	void Start () {
        currentHp = maxHp;
        anim = GetComponent<Animator>();
	}

    public void TakeDamage(int amount)
    {
        currentHp -= amount;
        Debug.Log("Stop hitting me!!! (HP: " + currentHp + ")");
        if (currentHp <= 0)
        {
            if(onDeath == DeathType.Destroy)
            {
                Destroy(this.gameObject);
            }
            else if (onDeath == DeathType.Disable)
            {
                this.gameObject.SetActive(false);
            }
            else if (onDeath == DeathType.Log_Message)
            {
                Debug.Log("I DIED!! HOW?! "+ this.gameObject.ToString());
            }
            else if (onDeath == DeathType.Play_Anim)
            {
                anim.SetBool("Dead",true);
            }
        }

    }
}
