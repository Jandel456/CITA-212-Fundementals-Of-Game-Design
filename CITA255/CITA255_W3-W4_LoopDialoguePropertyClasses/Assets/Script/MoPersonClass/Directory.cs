using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Directory : MonoBehaviour
{
    private void Start()
    {
        // List<int> ints - new List<int>();  This is the same kind of logic we're going to use for the next line

        //MoPerson moPerson = new MoPerson();
        MoPerson alex = new MoPerson("alex", 123);      // we're adding a new Moperson and then giving him a name and an Mnumber of 123
        MoStudent lily = new MoStudent("lily", 234, 4.0f);
        MoFalculty diane = new MoFalculty("diane", 345, 9999999);
        Debug.Log(lily.IntroduceMe());
        Debug.Log(diane.IntroduceMe());


    }
}
