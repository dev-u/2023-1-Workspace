using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TestTools;

public class TesteDePlayMode
{
    // A Test behaves as an ordinary method
    [Test]
    public void TesteDePiClass()
    {
        var obj = new Pi();
        obj.Multiply(50f);
        Assert.IsTrue(obj.IsMultipliedPiLessThanValue(10000));
    }

}
