
using UnityEngine;

public class DisableOnGameOver : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(SceneMng.getgameOver())
        {
            gameObject.SetActive(false);
        }
    }
}
