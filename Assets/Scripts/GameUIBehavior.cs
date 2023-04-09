using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameUIBehavior : MonoBehaviour
{
    public static int Score = 0;
    public TextMeshProUGUI Text;
    public static bool HasFailed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = Score.ToString();

        if (HasFailed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Score = 0;
            HasFailed = false;
        }
    }
}
