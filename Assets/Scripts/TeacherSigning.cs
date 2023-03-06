using TMPro;
using UnityEngine;

public class TeacherSigning : MonoBehaviour
{
    [Header("Registration")]
    [SerializeField] private TMP_InputField regNameField;
    [SerializeField] private TMP_InputField regPasswordField;
    [SerializeField] private TMP_InputField regFioField;

    [Header("Authorization")]
    [SerializeField] private TMP_InputField authNameField;
    [SerializeField] private TMP_InputField authPasswordField;

    [Header("UI")] 
    [SerializeField] private GameObject entryMenu;
    [SerializeField] private GameObject authorizationMenu;
    [SerializeField] private GameObject registrationMenu;
    [SerializeField] private GameObject mainMenu;
    
    [SerializeField] private Animator loginErrorAnim;
    [SerializeField] private Animator registerErrorAnim;

    [SerializeField] private LabLoader labLoader;

    private Nucleus _nucleus;
    
    private void Start()
    {
        _nucleus = Nucleus.instance;
        
        CheckTeacherLogin();
    }

    public void AuthorizeTeacher()
    {
        if (_nucleus.AuthorizeTeacher(authNameField.text, authPasswordField.text))
        {
            authorizationMenu.SetActive(false);
            SignIn();
        }
        else
        {
            loginErrorAnim.SetTrigger("Error");
            Debug.LogError("Authorization Error!");
        }
    }

    public void RegisterTeacher()
    {
        if (_nucleus.CreateTeacher(regNameField.text, regPasswordField.text, regFioField.text))
        {
            registrationMenu.SetActive(false);
            SignIn();
        }
        else
        {
            registerErrorAnim.SetTrigger("Error");
            Debug.LogError("Registration Error!");
        }
    }

    public void SignOut()
    {
        Nucleus.currentTeacherId = -1;

        labLoader.RemoveLabs();
        EnableEntry();
    }

    private void SignIn()
    {
        authNameField.text = string.Empty;
        authPasswordField.text = string.Empty;
        
        regNameField.text = string.Empty;
        regFioField.text = string.Empty;
        regPasswordField.text = string.Empty;

        EnableMenu();

        labLoader.LoadLabs();
    }
    
    private void EnableMenu()
    {
        entryMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    private void EnableEntry()
    {
        mainMenu.SetActive(false);
        entryMenu.SetActive(true);
    }

    private void CheckTeacherLogin()
    {
        if (Nucleus.instance.CheckAuthorization() == false) return;
        
        SignIn();
    }
}