using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePiege : MonoBehaviour
{
    //ATTRIBUTS
    private bool _estActive = false;
  //private Rigidbody _rb;

    [SerializeField] private List<GameObject> _listePieges = new List<GameObject>();
                     private List<Rigidbody> _listeRigidBody = new List<Rigidbody>(); 

    [SerializeField] private float intensiteForce = 600;

    private void Start()
    {
        foreach (var piege in _listePieges)
        {
            _listeRigidBody.Add(piege.GetComponent<Rigidbody>());
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_estActive)
        {
           Debug.Log("RUN RUN RUN");

            foreach (var rb in _listeRigidBody) 
            { 
                rb.useGravity = true;
                rb.AddForce(Vector3.down * intensiteForce);
                //Choisir une direction dans lequel la force est appliquer
                //Vector3 directionPerso = new Vector3(0f, -1f, 0f);
                //_rb.AddForce(directionPerso * intensiteForce);
            }
            
 
            _estActive = true;
        }
        
    }
}
