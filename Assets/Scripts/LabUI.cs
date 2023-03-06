using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabUI : MonoBehaviour
{
    public TextMeshProUGUI labNameText;
    public TextMeshProUGUI labDescriptionText;

    public int labId;
    
    /// <summary>
    /// Загрузить лабораторную работу
    /// </summary>
    public void LoadLab()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Отредактировать лабораторную работу
    /// </summary>
    public void EditLab()
    {
        LabEditor.instance.EditLab(labId, labNameText.text, labDescriptionText.text);
    }
    
    /// <summary>
    /// Удалить лабораторную работу
    /// </summary>
    public void DeleteLab()
    {
        LabLoader.instance.DeleteLab(labId);
        Destroy(this.gameObject);
    }
}
