using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class MoPerson
{
    public int mNum;
    public string name, type;

    //empty constructor
    public MoPerson()
    {
        mNum = 0;
        name = "[input name]";
        type = "MoPerson";
    }

    public MoPerson(string name, int mNum)
    {
        this.name = name;
        this.mNum = mNum;
        type = "MoPerson";
    }

    public virtual string IntroduceMe()
    {
        return "M Number: " + mNum +
                    "\nName: " + name +
                    "\nType: " + type;
    }


}
