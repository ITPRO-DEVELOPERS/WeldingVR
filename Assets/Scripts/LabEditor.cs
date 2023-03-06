using nsDB;
using TMPro;
using UnityEngine;

public class LabEditor : MonoBehaviour
{
    public static LabEditor instance;

    [Header("UI")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject editMenu;
    [SerializeField] private TMP_InputField titleInputField;
    [SerializeField] private TMP_InputField descriptionInputField;

    private int _editableLabId = -1;
    
    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }

    public void EditLab(int labId, string labName, string labDescription)
    {
        _editableLabId = labId;
        
        mainMenu.SetActive(false);
        editMenu.SetActive(true);

        titleInputField.text = labName;
        descriptionInputField.text = labDescription;
    }

    public void SaveLab()
    {
        Nucleus.instance.EditLab(_editableLabId, titleInputField.text, descriptionInputField.text);
        _editableLabId = -1;
        
        LabLoader.instance.ReloadLabs();
        
        editMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
