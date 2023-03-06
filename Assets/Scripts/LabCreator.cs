using TMPro;
using UnityEngine;

public class LabCreator : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField labNameField;
    [SerializeField] private TMP_InputField labDescriptionField;
    
    [SerializeField] private GameObject labCreationMenu;
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private LabLoader labLoader;
    
    public void CreateLab()
    {
        if (!Nucleus.instance.CreateLab(labNameField.text, labDescriptionField.text)) return;
        
        labNameField.text = string.Empty;
        labDescriptionField.text = string.Empty;
            
        labLoader.ReloadLabs();

        labCreationMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}