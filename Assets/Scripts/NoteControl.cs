using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoteControl : MonoBehaviour
{
    // Start is called before the first frame update
    private bool onNote;
    private string[] text;
    public GameObject note;
    public GameObject eImage;
    private void Update()
    {
        
        if (onNote && Input.GetKeyDown(KeyCode.E))
        {
            note.SetActive(true);
            eImage.SetActive(false);
        }
        if (onNote && note.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            note.SetActive(false);
            eImage.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            eImage.SetActive(true);
            onNote = true;
            text = collision.GetComponentInParent<Note>().Text;
            foreach (var item in text)
            {
                note.GetComponentInChildren<TextMeshProUGUI>().text += item + "\n";
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            note.SetActive(false);
            eImage.SetActive(false);
            onNote = false;
            note.GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
        }
    }
    public void Close()
    {
        note.SetActive(false);
        eImage.SetActive(true);
    }
}
