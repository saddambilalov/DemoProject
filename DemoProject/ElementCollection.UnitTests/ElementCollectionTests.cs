using System;
using System.Collections.ObjectModel;
using ElementCollection.Engine.FilterExtensions;
using ElementCollection.Infracture.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElementCollection.UnitTests
{
    [TestClass]
    public class ElementCollectionTests
    {

        #region Equals

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Exception()
        {
            ((Collection<Element>)null).FilterUniqueNumAndAgeBiggerThan20();
        }

        [TestMethod]
        public void Filter_Duplicate_Num_And_Age_Bigger_Than_20()
        {
            var input = new Collection<Element>
            {
                new Element
                {
                    Num = 1,
                    Age = 25,
                    Name = "Olivia"
                },
                new Element
                {
                    Num = 1,
                    Age = 22,
                    Name = "Isla"
                },
                new Element
                {
                    Num = 2,
                    Age = 24,
                    Name = "Emily"
                }
            };

            var expectedResult = new Collection<Element>
            {
                new Element
                {
                    Num = 1,
                    Age = 25,
                    Name = "Olivia"
                },
                new Element
                {
                    Num = 2,
                    Age = 24,
                    Name = "Emily"
                }
            };

            var result = input.FilterUniqueNumAndAgeBiggerThan20();

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Filter_Duplicate_Num_And_Age_Less_Than_20()
        {
            var input = new Collection<Element>
            {
                new Element
                {
                    Num = 1,
                    Age = 19,
                    Name = "Olivia"
                },
                new Element
                {
                    Num = 1,
                    Age = 19,
                    Name = "Isla"
                },
                new Element
                {
                    Num = 2,
                    Age = 19,
                    Name = "Emily"
                }
            };

            var expectedResult = new Collection<Element>();

            var result = input.FilterUniqueNumAndAgeBiggerThan20();

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Filter_No_Duplicate_Num_And_Age_Bigger_Than_20()
        {
            var input = new Collection<Element>
            {
                new Element
                {
                    Num = 1,
                    Age = 21,
                    Name = "Olivia"
                },
                new Element
                {
                    Num = 2,
                    Age = 22,
                    Name = "Isla"
                },
                new Element
                {
                    Num = 3,
                    Age = 23,
                    Name = "Emily"
                }
            };

            var expectedResult = new Collection<Element>
            {
                new Element
                {
                    Num = 1,
                    Age = 21,
                    Name = "Olivia"
                },
                new Element
                {
                    Num = 2,
                    Age = 22,
                    Name = "Isla"
                },
                new Element
                {
                    Num = 3,
                    Age = 23,
                    Name = "Emily"
                }
            }; ;

            var result = input.FilterUniqueNumAndAgeBiggerThan20();

            CollectionAssert.AreEqual(expectedResult, result);
        }

        #endregion

        #region Not_Equals

        [TestMethod]
        public void Filter_Duplicate_Num_And_Age_Bigger_Than_20_Not_Equals()
        {
            var input = new Collection<Element>
            {
                new Element
                {
                    Num = 1,
                    Age = 25,
                    Name = "Olivia"
                },
                new Element
                {
                    Num = 1,
                    Age = 22,
                    Name = "Isla"
                },
                new Element
                {
                    Num = 2,
                    Age = 24,
                    Name = "Emily"
                }
            };

            var expectedResult = new Collection<Element>
            {
                new Element
                {
                    Num = 1,
                    Age = 22,
                    Name = "Isla"
                },
                new Element
                {
                    Num = 2,
                    Age = 24,
                    Name = "Emily"
                }
            };

            var result = input.FilterUniqueNumAndAgeBiggerThan20();

            CollectionAssert.AreNotEqual(expectedResult, result);
        }

        [TestMethod]
        public void Filter_Duplicate_Num_And_Age_Less_Than_20_Not_Equals()
        {
            var input = new Collection<Element>
            {
                new Element
                {
                    Num = 1,
                    Age = 19,
                    Name = "Olivia"
                },
                new Element
                {
                    Num = 1,
                    Age = 20,
                    Name = "Isla"
                },
                new Element
                {
                    Num = 2,
                    Age = 19,
                    Name = "Emily"
                }
            };

            var expectedResult = new Collection<Element>
            {
                new Element
                {
                    Num = 1,
                    Age = 20,
                    Name = "Isla"
                }

            };

            var result = input.FilterUniqueNumAndAgeBiggerThan20();

            CollectionAssert.AreNotEqual(expectedResult, result);
        }

        #endregion
    }
}
