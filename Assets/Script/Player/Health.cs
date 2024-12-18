using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> heartList; //hacemos lista
    [SerializeField] private Sprite HeartOff;

    public void heartRest(int index)
    {
        Image imagHeart = heartList[index].GetComponent<Image>();
        imagHeart.sprite = HeartOff; // se cambia por la imagen en off
    }

}
