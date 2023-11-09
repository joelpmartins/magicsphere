using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public static Victory instance { get; private set; }
    [SerializeField] private InputActionReference _anyKeyValue;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        gameObject.SetActive(false);
    }

    private void Start()
    {
        SetText();
    }

    private void OnEnable()
    {
        _anyKeyValue.action.started += RestartGame;
    }

    private void OnDisable()
    {
        _anyKeyValue.action.started -= RestartGame;
    }

    public void DisplayVictoryPanel()
    {
        gameObject.SetActive(true);
    }

    private void SetText()
    {
        Transform[] ts = gameObject.GetComponentsInChildren<Transform>();
        ts = ts.ToList().OrderBy(e => e.name).ToArray();

        TextGeneration.instance.Print(ts[1], "Pressione uma tecla");
        TextGeneration.instance.Print(ts[2], "para recomecar...");
    }

    private void RestartGame(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
