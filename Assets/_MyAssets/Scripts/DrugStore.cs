using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugStore : MonoBehaviour
{
    private bool _estActive = false;

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player" && !_estActive)
        {
            Debug.Log("condom on");
            Renderer r1 = GameObject.Find("LowerCylinder").GetComponent<MeshRenderer>();
            r1.enabled = true;
            Renderer r2 = GameObject.Find("UpperCylinder").GetComponent<MeshRenderer>();
            r2.enabled = true;
            _estActive = true;
        }

    }
}
