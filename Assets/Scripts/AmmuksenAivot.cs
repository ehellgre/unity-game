using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmuksenAivot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Aina Coroutinea kutsuttaessa sen pitää palautaa IEnumerator
        StartCoroutine("TuhoaAmmus");
    }

    IEnumerator TuhoaAmmus()
    {
        // Odotetaan 3 sekuntia
        yield return new WaitForSeconds(3f);
        // Tuhotaan gameObject eli Ammus
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collisioninfo)
    {
        // Saadaan game objectin nimi tietoon, mihin on osuttu.
        Debug.Log("Ammus osui: " + collisioninfo.gameObject.name);

    }
}
