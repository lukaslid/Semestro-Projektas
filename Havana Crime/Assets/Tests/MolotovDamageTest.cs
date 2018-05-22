using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MolotovDamageTest
{
    [UnityTest]
    public IEnumerator MolotovDamageTesting()
    {
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("map2_img"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("MapObjects"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("A_"));
        yield return new WaitForSeconds(0.5f);
        GameObject enemy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("FastEnemy"), new Vector3(18, 3, 0), Quaternion.identity);
        GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"), new Vector3(-20, 3, 0), Quaternion.identity);
        GameObject molotov = MonoBehaviour.Instantiate(Resources.Load<GameObject>("molotov"), new Vector3(9, 3, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);

        float defaultEnemyHp = enemy.GetComponent<EnemyStats>().HP;
        yield return new WaitForSeconds(3);

        float enemyHP = enemy.GetComponent<EnemyStats>().HP;

        Assert.Greater(defaultEnemyHp, enemyHP);
    }
}
