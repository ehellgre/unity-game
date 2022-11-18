using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinariMain : MonoBehaviour
{
    // Einarin Rigidbody
    Rigidbody m_einarinFysiikka;

    // Einarin Animator
    Animator m_einarinAnimaatio;

    // Einari hyppyvoima
    [SerializeField] // SerializeFieldillä saadaan muuttuja näkyviin Unityn puolelle
    float m_einarinHyppyvoimaylospain = 300f;

    // Einarin liikevoima eteenpäin
    [SerializeField]
    float m_einarinEteenpainjuoksuvoima = 30f;

    // Einarin pyörimis'nopeus'
    [SerializeField]
    float m_einarinKaantovoima = 20f;

    //
    [SerializeField]
    GameObject m_ammuksenprefab;

    // Start is called before the first frame update
    void Start()
    {
        // Hakee Rigidbodyn Unityn puolelta ja tallentaa sen einarinFysiikka muuttujaan
        m_einarinFysiikka = GetComponent<Rigidbody>();
        m_einarinAnimaatio = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hyppy
        if (Input.GetKeyDown("space"))
        {
            // 0, 1, 0 * 500
            m_einarinFysiikka.AddForce(Vector3.up*m_einarinHyppyvoimaylospain);
            m_einarinAnimaatio.SetTrigger("Hyppy");
        }

        // Eteenpäin liikkuminen
        if (Input.GetKeyDown("w") || Input.GetKey("w")) // GetKeyDown = nappia painetaan & GetKey = nappi pohjassa
        {
            // Einarin nenän mukainen liikkumissuunta eli hahmon z akselin mukaisesti
            m_einarinFysiikka.AddRelativeForce(Vector3.forward*m_einarinEteenpainjuoksuvoima);
        }

        // Taaksepäin liikkuminen
        if (Input.GetKeyDown("s") || Input.GetKey("s"))
        {
            // Einarin nenän mukainen liikkumissuunta eli hahmon z akselin mukaisesti
            m_einarinFysiikka.AddRelativeForce(Vector3.back*m_einarinEteenpainjuoksuvoima);
        }

        // Pyöräytys oikealle
        if (Input.GetKeyDown("d") || Input.GetKey("d"))
        {
            m_einarinFysiikka.AddRelativeTorque(Vector3.up*m_einarinKaantovoima);
        }

        // Pyöräytys vasemmalle
        if (Input.GetKeyDown("a") || Input.GetKey("a"))
        {
            m_einarinFysiikka.AddRelativeTorque(Vector3.down*m_einarinKaantovoima);
        }

        // Aseen laukaiseminen
        if (Input.GetButtonDown("Fire1"))
        {
            //AmmuAmmus();
            m_einarinAnimaatio.SetTrigger("Ammu");
        }

        // Nopeuden selvittäminen
        // Rajataan y akseli eli ylöspäin pois ja otetaan käyttöön vain eteen- & taaksepäin liike
        Vector2 einarinnopeus = new Vector2(m_einarinFysiikka.velocity.x, m_einarinFysiikka.velocity.z);
        // Magnitude palauttaa pituuden
        float einarinlopullinennopeus = einarinnopeus.magnitude;
        m_einarinAnimaatio.SetFloat("EinarinNopeus", einarinlopullinennopeus);

    }

    public void AmmuAmmus()
    {
        GameObject ammuksenStarttipaikka = GameObject.Find("AmmuksenLahtopaikka");
        // Synnyttää uusia ammuksia jatkuvasti
        GameObject ammus = Instantiate(m_ammuksenprefab);     // GameObject.Find("Ammus");
        ammus.transform.position = ammuksenStarttipaikka.transform.position;

        // Ammuksen fysiikka
        Rigidbody ammuksenFysiikka = ammus.GetComponent<Rigidbody>();
        ammuksenFysiikka.velocity = Vector3.zero; // Jotta vanha voima ei vaikuttaisi:
        ammuksenFysiikka.AddForce(ammuksenStarttipaikka.transform.forward*500f);
    }

}
