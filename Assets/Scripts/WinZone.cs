using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    public Transform target;
    public float winRange = 0.5f;
    public float winTimer = 2f;
    public TextMeshProUGUI winText;

    void Start()
    {
        winText.gameObject.SetActive(false);
    }

    void Update()
    {
        var distance = Mathf.Sqrt(Mathf.Pow(target.position.x - this.transform.position.x, 2)
        + Mathf.Pow(target.position.y - this.transform.position.y, 2));

        if (distance < winRange)
        {
            WinUI();
            Invoke("ResetScene", winTimer);
        }
    }

    void WinUI()
    {
        winText.gameObject.SetActive(true);
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
