using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isHidden = false;
    private GameManager gameManager;
    public GameObject pelotaPrefab; // Asigna el prefab de la pelota desde el editor de Unity
    public GameObject particleEffectPrefab; // Asigna el prefab del sistema de partículas desde el editor de Unity

    private Puntos puntos;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
        puntos = Object.FindFirstObjectByType<Puntos>();
    }

    // Update is called once per frame
    void Update()
    {
        // Lógica del bloque en cada frame
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == pelotaPrefab)
        {
            isHidden = true;
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            gameManager.BlockHidden();
            puntos.AddPoints(10);

            // Instanciar el sistema de partículas
            Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}