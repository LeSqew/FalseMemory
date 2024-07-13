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
        scrollView_text.text = "первое воспоминание и информация о нём";
        Selected_Memory = 1;
    }
    public void ButtonTwo()
    {
        scrollView_text.text = "Один раз, когда патрулировали район, заметили подозрительного мальчишку.\nЯ с напарником подошли узнать, у него кто он и что делает.\nНо когда мы подошли мальчишка резко дернулся, в этот момент напарник выстрелил в мальчика из пистолета.\nОн начал истекать кровью. я вызвал медиков и стал пытаться как-то помочь.\nНапарник стоял и молча смотрел. Ему не было стыдно или обидно, он считал, что поступил правильно.\nСпустя время я узнал, что мальчик был болен болеpнью, из-за которой его руки могли иногда резко дергаться.\nМне так стыдно, что мальчик погиб. Я виню себя в произошедшем.";
        Selected_Memory = 2;
    }
    public void ButtonThree()
    {
        scrollView_text.text = "В 6 лет родилась сестрёнка. Cамое яркое воспоминание, как родители приехали с ней из роддома и показали сестру.\nОна была такой маленькой и беззащитной. \nПервое что я спросила: \"Когда она будет со мной играть?\"\nВсе посмеялись и тут же произошло первое разочарование - сестра не будет играть со мной прямо сейчас.";
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
