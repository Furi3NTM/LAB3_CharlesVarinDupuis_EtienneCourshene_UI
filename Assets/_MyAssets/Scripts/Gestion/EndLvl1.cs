using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if (collision.gameObject.tag == "Player" && _toucher == false)
        {
            int noScene = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(noScene + 1);
             Time.timeScale = 0;


        }
    }

}
