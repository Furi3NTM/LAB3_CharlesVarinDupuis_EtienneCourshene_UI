using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AffichageResultat : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtTempsTotal = default;
    [SerializeField] private TMP_Text _txtAccrochageTotal = default;
    [SerializeField] private TMP_Text _txtPointTotal = default;
    private GameManager _gameManager;


    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();

        _txtTempsTotal.text = "Temps total : " + (Time.time - _gameManager.GetTempsDepart()).ToString("f2") + "s";
        _txtAccrochageTotal.text = "Nombre d'accrochages : " + _gameManager.GetPointage().ToString();
        double _pointageTotal = (Time.time - _gameManager.GetTempsDepart()) + _gameManager.GetPointage();
        _txtPointTotal.text = "Pointage Final : " + _pointageTotal.ToString("f2") + "s";
        Debug.Log(_gameManager.GetPointage().ToString());
    }
}
