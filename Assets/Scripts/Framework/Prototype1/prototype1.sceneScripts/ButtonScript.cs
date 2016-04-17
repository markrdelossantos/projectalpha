using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    public void onClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
