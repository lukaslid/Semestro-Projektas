using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class SpeedBoostTest
{

    [UnityTest]
    public IEnumerator SpeedBoostWorkingTest()
    {
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("map2_img"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("MapObjects"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("A_"));
        GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"), new Vector3(18, 3, 0), Quaternion.identity);
        yield return new WaitForSeconds(2);
        float defaultSpeed = player.GetComponent<PlayerMobility>().speed;
        GameObject shoes = MonoBehaviour.Instantiate(Resources.Load<GameObject>("shoes"), new Vector3(18, 3, 0), Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
        float newSpeed = player.GetComponent<PlayerMobility>().speed;
        yield return new WaitForSeconds(1);
        Assert.Greater(newSpeed, defaultSpeed);
    }
}
