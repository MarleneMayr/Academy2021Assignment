using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI text;

    private void Start()
    {
        // make sure the endscreen is turned off from the beginning
        gameObject.SetActive(false);
    }

    private void Update()
    {
        // restart on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SetMessage(string message)
    {
        text.SetText(message);
    }
}
