using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject bgPanel;

    void Start()
    {
        LeanTween.rotateAround(bgPanel, Vector3.forward, -360, 10f).setLoopClamp();

        ClientCoordinator.Instance.OpenOverlay<ScoreShowUI>(showOnTop: true);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
            ClientCoordinator.Instance.Clear();
        }
    }
}
