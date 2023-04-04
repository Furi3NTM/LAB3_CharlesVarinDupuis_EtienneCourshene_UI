using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.SceneManagement;

public class EndLvl1 : MonoBehaviour
{
    private bool _toucher;
    private bool _finish;

    private GameManager _gameManager;
    private Player _player;

    private void Start()
    {
        _toucher = false;
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        //mettre l'objet qui VA toucher pas l'objet qui EST touch?
        if (collision.gameObject.tag == "Player" && _toucher == false)
        {

            //Récupere l'index de la scene en cours
            int noScene = SceneManager.GetActiveScene().buildIndex;




            SceneManager.LoadScene(noScene + 1);


        }
    }

}
