using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraAjo : MonoBehaviour
{
    [SerializeField]
    GameObject m_kohde;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Kamera seuraamaan Kohdetta eli Einaria
        // LookAt() katsoo jotain tiettyä transformia kohti
        transform.LookAt(m_kohde.transform);

        // m_kohde.transform.position = määrittää pelaajan paikan & (-m_kohde.transform.forward) = pelaajan paikasta taaksepäin 1 yksikkö
        // m_kohde.transform.up = nostetaan kameran paikkaa
        Vector3 loppupositio = m_kohde.transform.position-(m_kohde.transform.forward*10f) + (m_kohde.transform.up*3f);
        
        transform.position = Vector3.Lerp(transform.position, loppupositio, 0.01f);
    }
}
