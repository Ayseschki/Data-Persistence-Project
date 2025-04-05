using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // SceneManager için bu satýr eklendi

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
        bestScore = PlayerPrefs.GetInt("BestScore", 0); // Eðer "BestScore" kaydedilmemiþse 0 döner
        UpdateBestScoreText();

        // Butonlara iþlevsellik ekleyelim
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame); // QuitGame fonksiyonunu burada çaðýrýyoruz

        // Eðer önceden girilen bir player name varsa, InputField'a otomatik olarak ekleyelim
        playerNameInput.text = PlayerPrefs.GetString("PlayerName", "Ayþe");
    }

    void StartGame()
    {
        // Oyuncunun adýný PlayerPrefs'e kaydedelim
        PlayerPrefs.SetString("PlayerName", playerNameInput.text);

        // Oyuna baþlama iþlevi (oyunu baþlatan kodu burada yazabilirsin)
        Debug.Log("Oyuna Baþlatýldý!");
        SceneManager.LoadScene("Main"); // "Main" sahnesine geçiþ yapýyoruz
    }

    void QuitGame()
    {
        // Oyunu kapatma iþlevi
        Debug.Log("Oyundan çýkýlýyor.");
        Application.Quit();
    }

    void UpdateBestScoreText()
    {
        // Best score'u ekranda güncelle
        bestScoreText.text = "Best Score: " + bestScore;
    }
    void OnEnable()
    {
        // Sahne aktif olduðunda best score'u yenile
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScoreText();
    }
}
