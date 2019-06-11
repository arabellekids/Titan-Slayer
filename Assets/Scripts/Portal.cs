using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour {

    public string loadPointName;
    public Vector3 cameraOffset;
    public GameObject player;
    public string sceneName;
    public GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;

        var asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        asyncOperation.completed += TransportPlayer;
    }
    public void TransportPlayer(AsyncOperation _)
    {
        var loadPoint = GameObject.Find(loadPointName).transform.position;
        gameManager.player.transform.position = loadPoint;
        gameManager.mainCamera.transform.position = loadPoint + cameraOffset;
    }
}
