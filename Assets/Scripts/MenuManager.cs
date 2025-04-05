using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // SceneManager i�in bu sat�r eklendi

public class MenuManager : MonoBehaviour
{
    public Text bestScoreText; // Best score UI Text
    public InputField playerNameInput; // Input Field for Player Name
    public Button startButton; // Start Button
    public Button quitButton; // Quit Button

    private int bestScore = 0;

    void Start()
    {
        // Best score'u PlayerPrefs'ten al
        bestScore = PlayerPrefs.GetInt("BestScore", 0); // E�er "BestScore" kaydedilmemi�se 0 d�ner
        UpdateBestScoreText();

        // Butonlara i�levsellik ekleyelim
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame); // QuitGame fonksiyonunu burada �a��r�yoruz

        // E�er �nceden girilen bir player name varsa, InputField'a otomatik olarak ekleyelim
        playerNameInput.text = PlayerPrefs.GetString("PlayerName", "Ay�e");
    }

    void StartGame()
    {
        // Oyuncunun ad�n� PlayerPrefs'e kaydedelim
        PlayerPrefs.SetString("PlayerName", playerNameInput.text);

        // Oyuna ba�lama i�levi (oyunu ba�latan kodu burada yazabilirsin)
        Debug.Log("Oyuna Ba�lat�ld�!");
        SceneManager.LoadScene("Main"); // "Main" sahnesine ge�i� yap�yoruz
    }

    void QuitGame()
    {
        // Oyunu kapatma i�levi
        Debug.Log("Oyundan ��k�l�yor.");
        Application.Quit();
    }

    void UpdateBestScoreText()
    {
        // Best score'u ekranda g�ncelle
        bestScoreText.text = "Best Score: " + bestScore;
    }
    void OnEnable()
    {
        // Sahne aktif oldu�unda best score'u yenile
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScoreText();
    }
}
