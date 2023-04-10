using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //ATTRIBUTS
    private int _pointage = 0;
    public bool timeStarted = false;
    public double startTime = 0;

    //AWAKE
    private void Awake()
    {
        int nbGameManager = FindObjectsOfType<GameManager>().Length;

        if (nbGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    //START
    private void Start()
    {
       

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Renderer r1 = GameObject.Find("LowerCylinder").GetComponent<MeshRenderer>();
            r1.enabled = false;
            Renderer r2 = GameObject.Find("UpperCylinder").GetComponent<MeshRenderer>();
            r2.enabled = false;
        }
    
    }

    //UPDATE
     private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }

   
    //MÉTHODES
    public void AugmenterPointage()
    {
        _pointage++;
        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ChangerPointage(_pointage);
    }

    public int GetPointage()
    {
        return _pointage;
    }

    public double GetTempsDepart()
    {
        return startTime;
    }

    public void PersonnageABouge()
    {
        timeStarted = true;
        startTime = Time.time;
        Debug.Log($"Premier mouvement du joueur: {startTime}");
    }


}
