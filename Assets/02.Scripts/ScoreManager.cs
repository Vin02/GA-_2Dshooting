using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //관리: 특정 데이터에 대한 무결성과 추가 수정 삭제 등과 관련된 게임 로직
    
    private static ScoreManager _instance;
    public static ScoreManager Instance => _instance;

    private int _bestScore;
    private int _currentScore;
    private int _lastRefreshScore;
    
    private const string BEST_SCORE_KEY = "BestScore";
    
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _currentScoreText;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    private void Start()
    {
        Refresh();
    }
    public void AddScore(int score)
    {
        if (score <=0) return;
        _currentScore += score;
        if (_currentScore > _bestScore)
        {
            // 저장(빈번하게 하면 인터럽트 때문에 렉걸림)
            _bestScore = _currentScore;
            PlayerPrefs.SetInt(BEST_SCORE_KEY, _bestScore);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey(BEST_SCORE_KEY))
        {
            _bestScoreText.text = PlayerPrefs.GetInt(BEST_SCORE_KEY).ToString();
        }
        Refresh();
    }

    private void Refresh()
    {
        if (_lastRefreshScore == _currentScore) return;
        _bestScoreText.text = $"Best Score: {_bestScore}";
        _currentScoreText.text = $"Current Score: {_currentScore}";
        _lastRefreshScore = _currentScore;
    }
}
