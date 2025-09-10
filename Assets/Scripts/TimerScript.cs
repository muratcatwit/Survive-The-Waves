using UnityEngine;
using TMPro;
public class TimerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] TextMeshProUGUI timetext;
    private float time;
    public GameObject player;

        void Update()
    {
        if(player.activeSelf==true)
        {
            time += Time.deltaTime;

            int mins = Mathf.FloorToInt(time / 60);
            int secs = Mathf.FloorToInt(time % 60);
            timetext.text = string.Format("{0:00}:{1:00}", mins, secs);
            Vector3 pos = new Vector3(111f, 1327f, 0f);
            transform.position = pos;
        }

        if (player.activeSelf == false)
        {
            Vector3 pos = new Vector3(1300f,800f, 0f);
            transform.position = pos;
        }
    }

    public void ResetTimer()
    {
        time=0f;
        timetext.text="00:00";
    }


}
