using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //ATTRIBUTS
    private int _pointage;
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
        _pointage = 0;
        Instruction();

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Renderer r1 = GameObject.Find("LowerCylinder").GetComponent<MeshRenderer>();
            r1.enabled = false;
            Renderer r2 = GameObject.Find("UpperCylinder").GetComponent<MeshRenderer>();
            r2.enabled = false;
        }
    }

    //MÉTHODES
    private static void Instruction()
    {
        Debug.Log("*** Course a obstacle ***");
        Debug.Log("*** Atteindre la fin du parcours le plus rapidement possible ***");
        Debug.Log("*** Chaque obstacle touché entraine une pénalitée ***");
    }

    public void AugmenterPointage()
    {
        _pointage++;
        Debug.Log("Le pointage est de " + _pointage);
    }

    public int GetPointage()
    {
        return _pointage;
    }
    public void PersonnageABouge()
    {
        timeStarted = true;
        startTime = Time.time;
        Debug.Log($"Premier mouvement du joeur: {startTime}");
    }


}
