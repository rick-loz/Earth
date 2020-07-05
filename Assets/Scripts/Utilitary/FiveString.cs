using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixString
{
    private string stringA;
    private string stringB;
    private string stringC;
    private string stringD;
    private string stringE;
    private string stringF;

    public SixString(string pStringA, string pStringB, string pStringC, string pStringD, string pStringE, string pStringF)
    {
        stringA = pStringA;
        stringB = pStringB;
        stringC = pStringC;
        stringD = pStringD;
        stringE = pStringE;
        stringF = pStringF;
    }

    public string A() { return this.stringA; }
    public string B() { return this.stringB; }
    public string C() { return this.stringC; }
    public string D() { return this.stringD; }
    public string E() { return this.stringE; }
    public string F() { return this.stringF; }
}
