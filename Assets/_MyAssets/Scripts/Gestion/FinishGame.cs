
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

    //Utiliser les methodes de d'autre classe
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
        
        if (collision.gameObject.tag == "Player" && _toucher == false)
        {

            //Change la couleur du mur
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;

            
            int noScene = SceneManager.GetActiveScene().buildIndex;

            if (noScene == 4)
            {
                //Arreter le joueur
                _player.StopJoueur();
            }
            else
            {
                SceneManager.LoadScene(noScene + 1);
                Time.timeScale = 0;
            }

        }
    }

    public double GetTemps()
    {
        double startTime = _gameManager.startTime;
        return (Time.time - startTime);
    }


}
