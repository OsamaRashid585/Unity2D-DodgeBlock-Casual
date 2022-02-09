using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int _lifes = 3;
  [SerializeField] private Text _lifeTxt;
    public bool IsGameOver = false;


    private void Awake()
    {
        Instance = this;
        _lifes = 3;
    }
    private void Start()
    {
        
        
    }
    private void Update()
    {
        _lifeTxt.text = "Life: " + _lifes.ToString();

        if(_lifes <= 0)
        {
            StartCoroutine(GameOver());
        }

    }

    public IEnumerator GameOver()
    {
        IsGameOver = true;
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);

    }

}
