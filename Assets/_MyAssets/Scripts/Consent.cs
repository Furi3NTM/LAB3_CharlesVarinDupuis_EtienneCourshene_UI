using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Consent : MonoBehaviour
{
    private bool _estActive = false;
    private bool translate;

    private void Start()
    {
        translate = false;
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player" && !_estActive)
        {
            Debug.Log("you got it babyyy");
            // GameObject.Find("Consent Barrier").transform.Translate(new Vector3(-50f, 0f, 0f) * Time.deltaTime);
            translate = true;
        }

    }

    private void Update()
    {
        if (translate)
        {
            GameObject.Find("Consent Barrier").transform.Translate(new Vector3(-50f, 0f, 0f));
        }
    }
}
