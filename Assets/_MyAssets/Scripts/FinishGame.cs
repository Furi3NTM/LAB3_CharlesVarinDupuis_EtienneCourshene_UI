
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    //Attributs
    private bool _toucher;
    private bool _finish;
    private bool _personnageABouge;

    //Utiliser les m?thodes de d'autre classe
    private GameManager _gameManager;
    private Player _player;

    private void Start()
    {
        _toucher = false;
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //mettre l'objet qui VA toucher pas l'objet qui EST touch?
        if (collision.gameObject.tag == "Player" && _toucher == false)
        {

            int erreurs = _gameManager.GetPointage();
            double startTime = _gameManager.startTime;
            double total = Time.time + erreurs - startTime;

            //Change la couleur du mur
            gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;

            //Récupere l'index de la scene en cours
            int noScene = SceneManager.GetActiveScene().buildIndex;

            if (noScene == 2)
            {

                //Afficher les informations sur mon jeu
                Debug.Log("BRAVO!, ton temps est de : " + (Time.time - startTime) + " secondes");
                Debug.Log("Vous avez accroche " + erreurs + " obstacles");
                Debug.Log("Votre temps total est donc de " + total + " secondes");

                //Arreter le joueur
                _player.StopJoueur();
            }
            else
            {
                SceneManager.LoadScene(noScene + 1);
            }


        }
    }


}
