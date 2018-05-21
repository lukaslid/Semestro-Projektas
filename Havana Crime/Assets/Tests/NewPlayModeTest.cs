using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewPlayModeTest
{
    GameObject player;
    [UnityTest]
    public IEnumerator LoadScene()
    {
        SetupScene();
        Wait(5);

        yield return new WaitForSeconds(3);
    }

    void SetupScene()
    {
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("map2_img"));
        player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"), new Vector3(15,3,0), Quaternion.identity);
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("MapObjects"));
    }

    [UnityTest]
    public IEnumerator WalkkUp()
    {
        while (!Input.GetKeyDown(KeyCode.W))
        { }
                   
        Vector3 position1 = player.transform.position;
        Vector3 position2 = player.transform.position;

        if (Input.GetKeyDown(KeyCode.W))
        {
            position2 = player.transform.position;
        }

        if (position1.y > position2.y)
        {
            yield break;

        }

        yield return new WaitForSeconds(5);
    }

    public IEnumerator Wait(float s)
    {
        yield return new WaitForSeconds(s);
    }
}
