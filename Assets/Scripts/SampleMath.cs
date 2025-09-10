using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SampleMath : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private Color origColor;

    public Transform target;
    public Vector3 origPos;

    public float shakeIntensity = 5f;
    public float dangerRange = 2f;
    public float deathRange = 0.5f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        origPos = transform.position;
        origColor = spriteRenderer.color;
    }

    void Update()
    {
        this.transform.position = origPos;

        var distance = Mathf.Sqrt(Mathf.Pow(target.position.x - this.transform.position.x, 2)
        + Mathf.Pow(target.position.y - this.transform.position.y, 2));
        var vectorDist = Vector3.Distance(target.position, this.transform.position);
        Debug.Log($"Distance {distance:F2}, Vector {vectorDist:F2}");

        if (distance < deathRange)
        {
            ResetScene();
        }
        else if (distance < dangerRange)
        {
            spriteRenderer.color = Color.red;
            Shake();
        }
        else
        {
            spriteRenderer.color = origColor;
        }
    }

    void Shake()
    {
        var newVector = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1));
        this.transform.position += newVector * Time.deltaTime * shakeIntensity;
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
