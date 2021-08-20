using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI textmessage;

    private void Start()
    {
        // make sure the endscreen is turned off from the beginning
        gameObject.SetActive(false);
    }

    private void Update()
    {
        // check for LMB mouse input that is not on UI object
        if (Input.GetButton("Fire1") && !EventSystem.current.IsPointerOverGameObject())
        {
            // restart scene on mouse click
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SetMessage(string message)
    {
        textmessage.SetText(message);
    }
}
