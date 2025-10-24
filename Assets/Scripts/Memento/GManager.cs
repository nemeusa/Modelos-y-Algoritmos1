using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    [SerializeField] GameObject[] rewinds;
    List<IRewind> _rewinds = new List<IRewind>();
    Coroutine _coroutineRewind;

    private void Awake()
    {
       foreach (var r in rewinds)
        {

            if (r.GetComponent<IRewind>() != null)
                _rewinds.Add(r.GetComponent<IRewind>());
        }
    }

    private void Start()
    {
        _coroutineRewind = StartCoroutine(CoroutineSave());
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    foreach (var r in _rewinds) r.Save(); 
        //}
        if (Input.GetKeyDown(KeyCode.E))
        { 
            if(_coroutineRewind != null)
                StopCoroutine(_coroutineRewind);

            _coroutineRewind = StartCoroutine(CoroutineLoad());
            //foreach (var r in _rewinds) r.Load(); 
        }
    }

    IEnumerator CoroutineSave()
    {
        while (true)
        {
            foreach (var r in _rewinds) r.Save();

            yield return null;
        }
    }

    IEnumerator CoroutineLoad()
    {
        bool remember = true;

        while (remember)
        {
            remember = false;
            foreach (var r in _rewinds)
            {
                r.Load();
                if (r.IsRemember())
                    remember = true;
            }
            yield return null;
        }
        _coroutineRewind = StartCoroutine(CoroutineSave());
    }
}
