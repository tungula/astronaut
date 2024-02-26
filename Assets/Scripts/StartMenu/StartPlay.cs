using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartPlay : MonoBehaviour
{
    public GameObject Stage1;
    public GameObject Stage1Players;
    public GameObject Planets;

    public GameObject Stage2;
    public GameObject Stage2Canvas;
    public GameObject PlanetsForMap;
    public GameObject Stage2Players;

    public GameObject Stage3;
    public GameObject Stage3Canvas;
    public GameObject PlanetLarge;


    public GameObject StageShared;

    public List<GameObject> PlanetsList;

    public GameObject PlayButton;
    public GameObject LoadingText;


    public GameObject PlayerWhite;
    public GameObject PlayerGreen;
    public GameObject PlayerPink;
    public GameObject PlayerCircle;
    //ფარის მიხედვით
    public Transform SelectedPLayer;

    private int GameState = 1;
    private int ActivePlanet = 2;
    private int Player = 1;    //1 - white, 2- Green , 3 - Pink

    bool isDrag;
    Vector3 mousePos;

    public Image progressBar;
    public TextMeshProUGUI scoreText;

    public GameObject VideoPlayer;

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            VideoPlayer.GetComponent<VideoPlayer>().source = VideoSource.VideoClip;
        }
        else if(Application.platform == RuntimePlatform.WebGLPlayer)
        {
            VideoPlayer.GetComponent<VideoPlayer>().source = VideoSource.Url;
            VideoPlayer.GetComponent<VideoPlayer>().url = "http://46.49.107.53:8082/cosmo.mp4";
        }

#if UNITY_EDITOR
            GameState = 1;
        SelectedPLayer = PlayerWhite.transform;
#endif

        if (GameState == 1)
        {
            SetStage1();
        }

        if (GameState == 2)
        {
            SetStage2();
            SetLastActivePlanet(ActivePlanet);


        }

        if (GameState == 3)
        {
            SetStage3();
        }

        if (Application.platform != RuntimePlatform.Android)
        {
            scoreText.text = "Screen Width : " + Screen.width + "; Height : " + Screen.height;
        }
    }

    public void PlayButtonClick()
    {
        if (GameState == 1)
        {
            SetStage2();
            GameState = 2;
        }
        else if (GameState == 2)
        {
            SetStage3();
            GameState = 3;

        }
        else if (GameState == 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Round1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (mousePos != Input.mousePosition) isDrag = true;

            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.transform.name);
                Debug.Log(hit.collider.transform.tag);
                Debug.Log(isDrag);

                if (hit.collider.transform.tag == "Play")
                {
                    //if (GameState == 1)
                    //{
                    //    SetStage2();
                    //    GameState = 2;
                    //}
                    //else if (GameState == 2)
                    //{
                    //    SetStage3();
                    //    GameState = 3;

                    //}
                    //else if (GameState == 3)
                    //{
                    //    string currentSceneName = SceneManager.GetActiveScene().name;
                    //    SceneManager.LoadScene("Round1");
                    //}

                    //string currentSceneName = SceneManager.GetActiveScene().name;
                    //SceneManager.LoadScene("Round1");
                }
                else if (hit.collider.transform.parent.tag == "PlayerWhite" || hit.collider.transform.parent.tag == "PlayerGreen" || hit.collider.transform.parent.tag == "PlayerPink")
                {
                    Enable(hit.collider.transform.parent);
                }
                else if (hit.collider.transform.tag == "Back")
                {
                    SetStage1();
                    GameState = 1;
                }
                else if (hit.collider.transform.tag == "Planet1" || hit.collider.transform.tag == "Planet2" || hit.collider.transform.tag == "Planet3" || hit.collider.transform.tag == "Planet4" || hit.collider.transform.tag == "Planet5" ||
                    hit.collider.transform.tag == "Planet6" || hit.collider.transform.tag == "Planet7" || hit.collider.transform.tag == "Planet8")
                {
                    if (!isDrag) JumpToPlanet(hit.collider.transform.tag);
                }

                //Debug.Log(hit.collider.transform.parent.name);
            }
            isDrag = false;
        }
    }

    void Enable(Transform go)
    {
        SelectedPLayer = go;

        FindGameObjectInChildWithTag(PlayerWhite.transform, "ImgSelected").SetActive(false);
        FindGameObjectInChildWithTag(PlayerWhite.transform, "ImgNotSelected").SetActive(true);

        FindGameObjectInChildWithTag(PlayerGreen.transform, "ImgSelected").SetActive(false);
        FindGameObjectInChildWithTag(PlayerGreen.transform, "ImgNotSelected").SetActive(true);

        FindGameObjectInChildWithTag(PlayerPink.transform, "ImgSelected").SetActive(false);
        FindGameObjectInChildWithTag(PlayerPink.transform, "ImgNotSelected").SetActive(true);

        FindGameObjectInChildWithTag(go, "ImgSelected").SetActive(true);
        FindGameObjectInChildWithTag(go, "ImgNotSelected").SetActive(false);

        //round.transform.position = go.position;


        //float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y + distToPlayer, ref velocity.y, smoothTimeY);

        //if (Input.GetMouseButton(0) || player.transform.position.y > transform.position.y - 2.6)
        {
            StartCoroutine(WaitAndMove(0, PlayerCircle.transform, go));
        }
    }

    IEnumerator WaitAndMove(float delayTime, Transform from, Transform to)
    {
        //Debug.Log(from.name);
        //Debug.Log(to.name);
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (Time.time - startTime <= 1)
        { // until one second passed
            from.position = Vector3.Lerp(from.position, to.position, Time.time - startTime); // lerp from A to B in one second
            yield return 1; // wait for next frame
        }
    }

    IEnumerator WaitAndMove2(Transform from, Transform to, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = from.position;

        while (elapsedTime < seconds)
        { // until one second passed
            //Debug.Log((elapsedTime / seconds));
            from.position = Vector3.Lerp(startingPos, to.position + new Vector3(0, 2.31f, 0), (elapsedTime / seconds)); // lerp from A to B in one second
            elapsedTime += Time.deltaTime;
            yield return 1;
        }

        //from.position = to.position;
    }

    IEnumerator WaitAndMove3(Transform from, Transform to, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = from.position;

        while (elapsedTime < seconds)
        { // until one second passed
            //Debug.Log((elapsedTime / seconds));
            from.position = Vector3.Slerp(startingPos, to.position + new Vector3(0, 2.31f, 0), (elapsedTime / seconds)); // lerp from A to B in one second
            elapsedTime += Time.deltaTime;
            yield return 1;
        }

        //from.position = to.position;
    }

    void SetStage1()
    {
        Stage1.SetActive(true);

        Stage2.SetActive(false);
        Stage2Canvas.SetActive(false);

        Stage3.SetActive(false);
        Stage3Canvas.SetActive(false);

        StageShared.SetActive(true);
    }

    void SetStage2()
    {
        Stage1.SetActive(false);

        Stage2.SetActive(true);
        Stage2Canvas.SetActive(true);

        Stage3.SetActive(false);
        Stage3Canvas.SetActive(false);

        StageShared.SetActive(true);

        SetLastActivePlanet(ActivePlanet);

        SetPlayer(ActivePlanet);
    }

    void SetStage3()
    {
        Stage1.SetActive(false);

        Stage2.SetActive(false);
        Stage2Canvas.SetActive(false);

        Stage3.SetActive(true);
        Stage3Canvas.SetActive(true);

        StageShared.SetActive(false);

        Stage2Players.transform.SetParent(null);
        Stage2Players.transform.position = new Vector3(0, -1.2f, 10);

        //Invoke("CountTanks", 2);

        StartCoroutine(LoadSceneAsync(""));

    }


    IEnumerator LoadSceneAsync(string levelName)
    {
        //loadingPanel.SetActive(true);
        AsyncOperation op = SceneManager.LoadSceneAsync("Round1");
        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            Debug.Log(op.progress);

            progressBar.fillAmount = op.progress;
            //loadingBar.value = progress;
            //loadingText.text = progress * 100f + "%";
            yield return null;
        }
    }


    void CountTanks()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Round1");
    }

    void SetLastActivePlanet(int index)
    {
        for (int i = 0; i < 8; i++)
        {
            var plnt = FindGameObjectInChildWithTag(PlanetsList[i].transform, "PlanetLock");
            var plntLink = FindGameObjectInChildWithTag(PlanetsList[i].transform, "PlanetLink");

            if (i <= index)
            {
                plnt.SetActive(false);
            }
            else
            {
                plnt.SetActive(true);
            }

            if (i < index)
            {
                plntLink.SetActive(false);
            }
            else
            {
                plntLink.SetActive(true);
            }

            if (i == 7) plntLink.SetActive(false);


        }
    }


    public static GameObject FindGameObjectInChildWithTag(Transform parent, string tag)
    {
        Transform t = parent;

        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.tag == tag)
            {
                return t.GetChild(i).gameObject;
            }

        }

        return null;
    }

    void MakeLargePlanetAnimation()
    {

    }

    void JumpPlayer(int endIndex)
    {
        StartCoroutine(WaitAndMove3(Stage2Players.transform, PlanetsList[endIndex].transform, 3.0f));
    }

    void SetPlayer(int index)
    {
        var white = FindGameObjectInChildWithTag(Stage2Players.transform, "PlayerWhite");
        var green = FindGameObjectInChildWithTag(Stage2Players.transform, "PlayerGreen");
        var pink = FindGameObjectInChildWithTag(Stage2Players.transform, "PlayerPink");

        white.SetActive(SelectedPLayer.tag == "PlayerWhite");
        green.SetActive(SelectedPLayer.tag == "PlayerGreen");
        pink.SetActive(SelectedPLayer.tag == "PlayerPink");

        Stage2Players.transform.SetParent(PlanetsList[index].transform);
        Stage2Players.transform.position = new Vector3(PlanetsList[index].transform.position.x, PlanetsList[index].transform.position.y + 2.31f, PlanetsList[index].transform.position.z);

    }

    void JumpToPlanet(string tag)
    {
        int index = Convert.ToInt32(tag.Substring(6, 1)) - 1;

        var plnt = FindGameObjectInChildWithTag(PlanetsList[index].transform, "PlanetLock");

        Debug.Log(index);


        if (plnt.active) return;

        //TODO
        //JumpPlayer(index);


        Stage2Players.transform.SetParent(PlanetsList[index].transform);
        Stage2Players.transform.position = new Vector3(PlanetsList[index].transform.position.x, PlanetsList[index].transform.position.y + 2.31f, PlanetsList[index].transform.position.z);

    }
}
