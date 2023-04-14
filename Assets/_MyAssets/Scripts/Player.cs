using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Attributs 
    [SerializeField] private float _vitesse = 800;
    private bool _estActif = true;
    private bool playerMoved;
    private Rigidbody _rb;


    // Méthodes privées
   private void Start()
    { 
        _rb = GetComponent<Rigidbody>();
        GameManager gameManager = FindObjectOfType<GameManager>();
        playerMoved = gameManager.timeStarted;

    }


    private void FixedUpdate()
    {
        if (_estActif)
        {
         MouvementsJoueur();
        }
        
   
    }
    

    private void MouvementsJoueur()
    {

        float positionX = Input.GetAxis("Horizontal");
        float positionZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(positionX, 0f, positionZ);
        //transform.Translate(direction * Time.deltaTime * _vitesse);
        _rb.velocity = direction * Time.fixedDeltaTime * _vitesse;



        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            if (!playerMoved)
            {
                playerMoved = true;
                GameManager gameManager = FindObjectOfType<GameManager>();
                gameManager.PersonnageABouge();
            }
        }
        else if (Input.GetKey("down") || Input.GetKey("s"))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            if (!playerMoved)
            {
                playerMoved = true;
                GameManager gameManager = FindObjectOfType<GameManager>();
                gameManager.PersonnageABouge();
            }
        }
        else if (Input.GetKey("right") || Input.GetKey("d"))
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            if (!playerMoved)
            {
                playerMoved = true;
                GameManager gameManager = FindObjectOfType<GameManager>();
                gameManager.PersonnageABouge();
            }
        }
        else if (Input.GetKey("left") || Input.GetKey("a"))
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            if (!playerMoved)
            {
                playerMoved = true;
                GameManager gameManager = FindObjectOfType<GameManager>();
                gameManager.PersonnageABouge();
            }
        }
    }

    public void StopJoueur()
    {
        this.gameObject.SetActive(false);
    }
   
}