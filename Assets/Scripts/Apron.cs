using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class Apron : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject nextItem;
    [SerializeField] private string item;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject canvas1;
    public Back back;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Body"))
        {
            if (back.count == 3)
            {
                canvas.SetActive(true);
                canvas1.transform.position= Vector3.zero;
            }
            Destroy(this.gameObject);
            text.text = item;
            back.count++;
            nextItem.SetActive(true);
            
        }
    }
}
