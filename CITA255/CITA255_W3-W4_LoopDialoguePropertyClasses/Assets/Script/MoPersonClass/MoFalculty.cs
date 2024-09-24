using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoFalculty : MoPerson
{
    public int salary;

    public MoFalculty(string name, int mNum, int salary) : base(name, mNum)     // name and Mnum are derived from MoPerson so we use base name and mNUm for that
    {
        this.salary = salary;
        type = "MoFalculty";
    
    }

    public override string IntroduceMe()
    {
        return base.IntroduceMe() + "\n Salary: " + salary;
    }
}
