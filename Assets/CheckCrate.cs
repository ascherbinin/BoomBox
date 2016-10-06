using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CheckCrate : MonoBehaviour {

    [SerializeField]
    private bool inCollider = false;
    private float delayTime = 3;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "MainCrate")
        {
            inCollider = true;
            StartCoroutine("nextLevel");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCrate")
        {
            inCollider = false;
        }
    }

    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(delayTime);
        if (inCollider)
        {
            SceneManager.LoadScene(1);
        }
    }
}
