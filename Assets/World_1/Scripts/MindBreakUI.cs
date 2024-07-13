using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MindBreakUI : MonoBehaviour
{
    public string Password;
    public TMPro.TMP_InputField InputField;
    public GameObject canvas;
    private void Start()
    {
    }
    public void Escape()
    {
        canvas.SetActive(false);
    }
    public void Check()
    {
        if (InputField.text == Password)
        {
            Debug.Log(123);
            Escape();
            SceneManager.LoadScene(1);
        }
        else
        {
            InputField.text = string.Empty;
        }
    }
}
