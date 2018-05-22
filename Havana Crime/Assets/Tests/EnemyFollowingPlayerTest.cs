using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class EnemyFollowingPlayer
{
    [UnityTest]
    public IEnumerator EnemyFollowingPlayerTest()
    {
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("map2_img"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("MapObjects"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("A_"));
        GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"), new Vector3(18, 3, 0), Quaternion.identity);
        GameObject enemy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FastEnemy"), new Vector3(5, 3, 0), Quaternion.identity);

        float distance1 = player.transform.position.x - enemy.transform.position.x; //pradinis atstumas tarp zaidejo ir zombio
        yield return new WaitForSeconds(1);
        float distance2 = player.transform.position.x - enemy.transform.position.x;// atstumas kai zombis seka zaideja 1s

        Assert.Greater(distance1, distance2);
    }
}
