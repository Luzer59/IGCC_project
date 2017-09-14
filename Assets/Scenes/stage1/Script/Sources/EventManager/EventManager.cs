using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {


    //eventlist
    private List<ScriptEvent> eventlist;

    public static EventManager instance;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        eventlist = new List<ScriptEvent>();

    }

    // Update is called once per frame
    public void Update()
    {


        if (eventlist.Count < 1)
            return;

        for (int i = 0; i < eventlist.Count; i++)
        {
            if (eventlist[i].lifetime > 0)
            {
                eventlist[i].Run();
            }
            else
            {
                eventlist.RemoveAt(i);
            }
        }

    }

    public void AddEvent(ScriptEvent _event)
    {
        if (!_event)
            return;

        eventlist.Add(_event);
    }


}
