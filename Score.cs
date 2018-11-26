using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Tetris
{
    public class Score : MonoBehaviour
    {

        public Text scoreText;
        private Text scoreGT;
        public static int currentScore = 0;
        public GameObject Block2d;
        public GameObject border2d;
        // Use this for initialization
        void Start()
        {
            scoreText = GameObject.Find("score").GetComponent<Text>();
        }

       public void UpdateScore()
        {
            PlayerPrefs.SetInt("score", currentScore);
            currentScore += 100;
            scoreGT.text = "score:" + currentScore.ToString();
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}