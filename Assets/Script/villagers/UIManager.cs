using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject textbox;
    [SerializeField] private TMP_Text diagtext;

    // Start is called before the first frame update

    public void activeDesactiveBoxText(bool activado) //publicos para poder llamarlos
    {
        textbox.SetActive(activado); //activo el text
    }
    public void viewText(string Text)
    {
        diagtext.text = Text.ToString(); //paso a texto
    }

}
