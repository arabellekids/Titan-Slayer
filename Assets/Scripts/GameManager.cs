using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityStandardAssets.Characters.ThirdPerson;
public class GameManager : MonoBehaviour
{
    public string gameSceneName;
    public GameObject playerPref;
    public GameObject cameraPref;
    Vector3 playerSpawnPoint;
    public Vector3 cameraOffset;

    public string spawnPointName;
    public GameObject player;
    public GameObject mainCamera;
    public string loadPointName;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame(AsyncOperation _)
    {
        playerSpawnPoint = GameObject.Find(spawnPointName).transform.position;
        player = Instantiate(playerPref, playerSpawnPoint, playerPref.transform.rotation);
        DontDestroyOnLoad(player);
        mainCamera = Instantiate(cameraPref, playerSpawnPoint + cameraOffset, cameraPref.transform.rotation);
        DontDestroyOnLoad(mainCamera);

        //var cameraAssigned = player.GetComponent<ThirdPersonUserControl>().AssignCamera(Camera.main.transform);
    }
    public void OnClickPlay()
    {
        var asyncOperation = SceneManager.LoadSceneAsync(gameSceneName, LoadSceneMode.Single);
        asyncOperation.completed += StartGame;
    }
}
