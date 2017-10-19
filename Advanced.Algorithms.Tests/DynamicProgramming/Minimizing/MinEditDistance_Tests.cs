﻿using Advanced.Algorithms.DynamicProgramming.Minimizing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.Algorithms.Tests.DynamicProgramming.Minimizing
{
    /// <summary>
    /// Problem statement below
    /// http://www.geeksforgeeks.org/dynamic-programming-set-5-edit-distance/
    /// </summary>
    [TestClass]
    public class MinEditDistance_Tests
    {
        [TestMethod]
        public void MinEditDistance_Smoke_Test()
        {
            Assert.AreEqual(1, MinEditDistance.GetMin("geek", "gesek"));
            Assert.AreEqual(1, MinEditDistance.GetMin("cat", "cut"));
            Assert.AreEqual(3, MinEditDistance.GetMin("sunday", "saturday"));
        }
    }
}