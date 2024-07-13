using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UI_List_Person_Info : MonoBehaviour
{
    public TMP_Text scrollView_text;
    public PlayerController player;
    public int Selected_Memory = -1;
    public bool Select_Change;

    // Start is called before the first frame update
    void Start()
    {
        scrollView_text.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonOne()
    {
        scrollView_text.text = "������ ������������ � ���������� � ��";
        Selected_Memory = 1;
    }
    public void ButtonTwo()
    {
        scrollView_text.text = "���� ���, ����� ������������� �����, �������� ��������������� ���������.\n� � ���������� ������� ������, � ���� ��� �� � ��� ������.\n�� ����� �� ������� ��������� ����� ��������, � ���� ������ �������� ��������� � �������� �� ���������.\n�� ����� �������� ������. � ������ ������� � ���� �������� ���-�� ������.\n�������� ����� � ����� �������. ��� �� ���� ������ ��� ������, �� ������, ��� �������� ���������.\n������ ����� � �����, ��� ������� ��� ����� ����p���, ��-�� ������� ��� ���� ����� ������ ����� ���������.\n��� ��� ������, ��� ������� �����. � ���� ���� � ������������.";
        Selected_Memory = 2;
    }
    public void ButtonThree()
    {
        scrollView_text.text = "� 6 ��� �������� ��������. C���� ����� ������������, ��� �������� �������� � ��� �� ������� � �������� ������.\n��� ���� ����� ��������� � �����������. \n������ ��� � ��������: \"����� ��� ����� �� ���� ������?\"\n��� ���������� � ��� �� ��������� ������ ������������� - ������ �� ����� ������ �� ���� ����� ������.";
        Selected_Memory = 2;
    }

    public void But_Yes()
    {
        player.open_List = false;
        player.Info_List.SetActive(false);

        Select_Change = true;
        if (Selected_Memory != -1) Next(Selected_Memory);
    }

    public void Next(int number)
    {
        SceneManager.LoadScene(number+1);
    }

    public void But_No()
    {
        player.open_List = false;
        player.Info_List.SetActive(false);
    }
    }
