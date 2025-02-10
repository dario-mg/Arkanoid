using TMPro;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    public TextMeshProUGUI numPoints;
    private int currentPoints = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Inicializar currentPoints con el valor almacenado en PlayerPrefs
        currentPoints = PlayerPrefs.GetInt("Puntuacion", 0);
        UpdateScoreUi();
    }


    public void AddPoints(int points) // Corrección del nombre del método
    {
        currentPoints += points; // Usar el parámetro points en lugar de un valor fijo
        UpdateScoreUi();
        PlayerPrefs.SetInt("Puntuacion", currentPoints);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void UpdateScoreUi()
    {
        numPoints.text = currentPoints.ToString("000");
    }
}