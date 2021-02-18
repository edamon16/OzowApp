using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace Sorting.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodInt()
        {
            SortingFacade sorting = new SortingFacade();
            var value = new [] { 2, 5, 6, 8, 9, 4, 10 };
            var expected = new int[] { 2, 4, 5, 6, 8, 9, 10 };
            var result = sorting.Sorting(value);
            CollectionAssert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethodString()
        {
            SortingFacade sorting = new SortingFacade();
            var value = new[] { "Contrary", "to", "popular", "belief,", "the" ,"pink", "unicorn", "flies", "east" };

            var expected =  "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy" ;
           
            var result = sorting.Sorting(value);
       
            Assert.AreEqual(expected, result);
        }

    
      
    }
}
