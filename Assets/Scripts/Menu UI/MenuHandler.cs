using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    // component
    [SerializeField] TextMeshProUGUI bestText;
    [SerializeField] TMP_InputField nameField;

    // string
    private string userName;

    // Start is called before the first frame update
    void Start()
    {
        bestText.text = "Best Score: " + DataManager.Intance.user + " " +
            DataManager.Intance.score;

        nameField.text = DataManager.Intance.user;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Input typing
    public void TypeChange()
    {
        userName = nameField.text;
    }

    // Start button clicked
    public void StartGame()
    {
        DataManager.Intance.newUser = userName;

        SceneManager.LoadScene(1);
    }

    // Exit button clicked
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
