using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace group1.Breakout.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        private int _brickCount, _lifeCount, _score;
        private bool _isGameOver;
        [SerializeField] private Transform bricks;
        [SerializeField] private Toggle[] lives;
        [SerializeField] private RectTransform loseScreen, winScreen;
        [SerializeField] private TextMeshProUGUI score;
        [SerializeField] private float time;


        public void CollideBrick(Collision other)
        {
            if (_isGameOver) return;
            _brickCount--;
            other.gameObject.SetActive(false);
            score.text = $"Score: {++_score}";
            if (_brickCount > 0) return;
            _isGameOver = true;
            winScreen.gameObject.SetActive(true);
            Invoke(nameof(Restart), time);
        }

        public void CollideWater() 
        {
            if (_isGameOver) return;
            _lifeCount--;
            if (_lifeCount >=0)
            {
                lives[_lifeCount].gameObject.SetActive(false);
            }
            score.text = $"Score: {--_score}";
            if (_lifeCount > 0) return;
            _isGameOver = true;
            loseScreen.gameObject.SetActive(true);
            Invoke(nameof(Restart), time);

        }

        public void Restart() 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Reset() 
        {
            bricks = null;
            lives = null;
            loseScreen = null;
            score = null;
            winScreen = null;
            time = 5;
        }

        // Start is called before the first frame update
        void Start()
        {
            _brickCount = 32;
            _isGameOver = false;
            _lifeCount = 5;
            Time.timeScale = 0;

        }

        // Update is called once per frame
        void Update()
        {
            if (_isGameOver) return;
            if (Input.GetKeyDown(KeyCode.R)) {
                // restart the game
                Reset();
                Restart();
            }
            if (Input.GetKeyDown(KeyCode.Escape)) {
                // pause the game
                Time.timeScale = 0;
            }
            if (Input.GetKeyDown(KeyCode.Return)) {
                // resume the game
                Time.timeScale = 1;
            }
        }
    }
}
