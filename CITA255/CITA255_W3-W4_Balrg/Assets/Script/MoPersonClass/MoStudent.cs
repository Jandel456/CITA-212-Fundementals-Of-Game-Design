using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoStudent : MoPerson       // we delete Monobehavior because we want Mostudent to inherit from MoPerson
{
    public float gpa;

    public MoStudent(string name, int mNum, float gpa) : base(name, mNum)
    {
        type = "MoStudent";
        this.gpa = gpa;

    }

    public override string IntroduceMe()
    {
        return base.IntroduceMe() + "\nGPA: " + gpa;
    }
}
