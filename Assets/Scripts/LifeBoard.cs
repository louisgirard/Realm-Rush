using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeBoard : MonoBehaviour
{
    int lives = 5;
    Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
        livesText.text = lives.ToString();
    }

    public void LoseLife(int livesToLose)
    {
        lives -= livesToLose;
        livesText.text = lives.ToString();
        if(lives <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}