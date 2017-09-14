using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage3Judge : StageJudge
{
    [SerializeField]
    private GameObject monster;

    private Vector3 monsterpos;

    protected override void Start()
    {
        base.Start();
        monsterpos = monster.transform.position;
        monster.GetComponent<Enemy>().movementMode = Enemy.MovementMode.Free;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            monster.transform.position = monsterpos;
        }
    }
}
