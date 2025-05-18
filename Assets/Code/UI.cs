using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private Player Jugador;
    public TextMeshProUGUI points;
    int SceneManagement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Jugador = playerObject.GetComponent<Player>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        points.text = Jugador.points.ToString();
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  
}
