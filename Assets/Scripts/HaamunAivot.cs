using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HaamunAivot : MonoBehaviour
{
    Animator m_haamunAnimaatiot;

    NavMeshAgent m_haamunPolunetsinta;


    // Start is called before the first frame update
    void Start()
    {
        // Haetaan Ghost objektista Animator komponentti
        m_haamunAnimaatiot = GetComponent<Animator>();
        // Haetaan Ghost objektista NavMeshAgent komponentti
        m_haamunPolunetsinta = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Einari Tag = Player, joten FindWithTag("Player") = Etsi Einari
        GameObject target = GameObject.FindWithTag("Player");
        m_haamunPolunetsinta.destination = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision osumainfo)
    {
        Debug.Log("Haamuun osui: " + osumainfo.gameObject.name);

        // Contains tarkistaa onko Stringissä sana Ammus
        if (osumainfo.gameObject.name.Contains("Ammus"))
        {
            m_haamunAnimaatiot.SetTrigger("HaamuunOsuiAmmus");
        }
    }
}
