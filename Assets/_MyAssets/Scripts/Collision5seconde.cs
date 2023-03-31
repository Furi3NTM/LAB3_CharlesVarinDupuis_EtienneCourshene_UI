using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision5seconde : MonoBehaviour
{
    //Attribut
    private GameManager _gameManager;
    private bool _toucher;
    private Color _couleurOrigine;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _toucher = false;
        _couleurOrigine = gameObject.GetComponent<MeshRenderer>().material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && _toucher == false)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            _gameManager.AugmenterPointage();
            _toucher = true;
            StartCoroutine(RestaurerCouleurOrigine());
        }
    }

    private IEnumerator RestaurerCouleurOrigine()
    {
        yield return new WaitForSeconds(4.0f);
        gameObject.GetComponent<MeshRenderer>().material.color = _couleurOrigine;
        _toucher = false;
    }
}
