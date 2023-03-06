using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
         canvas.SetActive(true);
    }
}
