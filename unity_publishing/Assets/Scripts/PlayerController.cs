using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10f;

    [SerializeField] private Text healthText;
    private int health = 5;

    [SerializeField] private Text scoreText;
    private int score = 0;

    [SerializeField] private GameObject winLoseBG;
    [SerializeField] private Text winLoseText;

    [SerializeField] private GameObject firstTeleporter;
    [SerializeField] private GameObject secondTeleporter;
    private bool canTeleport = true;

    private void FixedUpdate() {
        GetInputs();
    }

    private void Update() {
        if (health == 0)
        {
            SetLoseBG();
        }
    }

    private void GetInputs() {
        Vector2 inputVector = new(0, 0);

        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = 1;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }

        inputVector = inputVector.normalized;

        Vector3 moveDir = new(inputVector.x, 0, inputVector.y);
        transform.position += playerSpeed * Time.deltaTime * moveDir;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Pickup")) {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        } else if (other.CompareTag("Trap")) {
            if (health > 0)
            {
                health--;
                SetHealthText();
            }
        } else if (other.CompareTag("Goal")) {
            SetWinBG();
        } else if (other.CompareTag("Teleporter")) {
            if (canTeleport) {
                if (other.gameObject == firstTeleporter) {
                    transform.position = new Vector3(secondTeleporter.transform.position.x, transform.position.y, secondTeleporter.transform.position.z);
                } else {
                    transform.position = new Vector3(firstTeleporter.transform.position.x, transform.position.y, firstTeleporter.transform.position.z);
                }
                canTeleport = false;
                Invoke(nameof(ResetTeleportCooldown), 0.1f);
            }
            
        }
    }

    private void ResetTeleportCooldown() {
        canTeleport = true;
    }

    private void SetScoreText() {
        scoreText.text = $"Score: {score}";
    }

    private void SetHealthText() {
        healthText.text = $"Health: {health}";
    }

    private void SetWinBG() {
        winLoseText.text = "You Win!";
        winLoseText.color = Color.black;
        winLoseBG.GetComponent<Image>().color = Color.green;
        winLoseBG.SetActive(true);

        StartCoroutine(LoadScene(3));
    }

    private void SetLoseBG() {
        winLoseText.text = "Game Over!";
        winLoseText.color = Color.white;
        winLoseBG.GetComponent<Image>().color = Color.red;
        winLoseBG.SetActive(true);

        StartCoroutine(LoadScene(3));
    }

    private IEnumerator LoadScene(float seconds) {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
