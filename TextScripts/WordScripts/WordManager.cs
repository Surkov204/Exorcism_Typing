using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    private bool hasActiveWord;
    private Word activeWord;

    public WordSpawner spawner;
    public float wordDelay;
    public GameObject endchapterbutton;
    private float nextWordTime = 0f;
    int Num;
    int _Num;
    int _Num2;
    int prNum2,cenNum;
    [SerializeField] private AudioClip sound;
    [SerializeField] private TextMeshProUGUI ScorePoint;
    [SerializeField] private TextMeshProUGUI HighScore;
    [SerializeField] private TextMeshProUGUI HighScoreBG;
    [SerializeField] private TextMeshProUGUI BestScore;


    private ShowTheScore theScore;
    
    private void Start()
    {
        endchapterbutton.SetActive(false);
        LoadGame();
        
        BestScore.text = "Best Score: " + _Num2;
        Num = 0;
        ScorePoint.text = "Score: " + Num;
        HighScore.text = " " + Num;
        if (prNum2 < _Num2)
        {
            prNum2 = _Num2;
            _Num2 = 0;
        }
        else
            _Num2 = 0;
            
       
       
        Debug.Log(prNum2);

    }
    private void Update()
    {
        if (Time.time >= nextWordTime)
        {
            Addword();
            nextWordTime = Time.time + wordDelay;
            wordDelay *= .99f;
        }
        HighScoreBG.text = "Your Words: " + _Num;

    }
    private void Addword()
    {
        Word word = new Word(WordGenerator.GetRandomWord(),spawner.SpawnWord());
        //Debug.Log(word.word);
        words.Add(word);
    }

    public void Typeletter(char latter)
    {
        if (hasActiveWord)
        {
            if (activeWord.GetNextLetter() == latter)
            {
                activeWord.TypeLetter();

            }
        }
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == latter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }

            }          
        }
        
        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);


            SoundManager.instance.PlaySound(sound);


            Num++;
            _Num++;
            _Num2++;


            ScorePoint.text = "Score: " + Num;
            HighScore.text = " " + Num;
            HighScoreBG.text = "Your Words: " + _Num +" /1000";
            BestScore.text = "Best Score: " + _Num2;
        }

    }
    public void SaveGame()
    {
        GameData data = new GameData();
    
        data.Score = _Num;
       
        Debug.Log("previous Num: "+ prNum2);
        Debug.Log("present Num: " + _Num2);
       
        if (prNum2 < _Num2)
        {
            data.BestScore = _Num2;
        } else
        {
            data.BestScore = prNum2;
        }
     
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + "/savegame.json", json);

    }
    public void LoadGame()
    {
        
        string json = File.ReadAllText(Application.persistentDataPath + "/savegame.json");
        GameData data = JsonUtility.FromJson<GameData>(json);
        _Num = data.Score;
        _Num2 = data.BestScore;
        if (_Num >= 1000)
        {
            Debug.Log("you finally end this game and agaist the ghost");

            if (endchapterbutton != null && !endchapterbutton.activeInHierarchy)
            {
                endchapterbutton.SetActive(true);
            }
          
        } else
        {
            endchapterbutton.SetActive(false);
        }
        

    }
    public void BacktoGame()
    {
        SaveGame();
        SceneManager.LoadScene("Chapter1");
        Time.timeScale = 1;
    }

}
