using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayControls : MonoBehaviour
{
    public GameObject controls;
    public float displayTimer = 5f;

    void Start()
    {
        StartCoroutine(ShowandHideText());
    }


    IEnumerator ShowandHideText()
    {
        controls.SetActive(true);

        yield return new WaitForSeconds(5f);

        controls.SetActive(false);
    }
}
