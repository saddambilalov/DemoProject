using System;
using System.Collections.ObjectModel;
using ElementCollection.Infracture.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElementCollection.UnitTests
{
    [TestClass]
    public class ElementCollectionTests
    {

        #region Pass

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Exception_Should_Pass()
        {
            ((Collection<Element>)null).FilterUniqueAndAgeBiggerThan20();
        }

        [TestMethod]
        public void Filter_Dublicate_Num_And_Age_Bigger_Than_20_Should_Pass()
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

            var result = input.FilterUniqueAndAgeBiggerThan20();

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Filter_Dublicate_Num_And_Age_Less_Than_20_Should_Pass()
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

            var result = input.FilterUniqueAndAgeBiggerThan20();

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Filter_No_Dublicate_Num_And_Age_Bigger_Than_20_Should_Fail()
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

            var result = input.FilterUniqueAndAgeBiggerThan20();

            CollectionAssert.AreEqual(expectedResult, result);
        }

        #endregion

        #region Fail

        [TestMethod]
        public void Filter_Dublicate_Num_And_Age_Bigger_Than_20_Should_Fail()
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

            var result = input.FilterUniqueAndAgeBiggerThan20();

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Filter_Dublicate_Num_And_Age_Less_Than_20_Should_Fail()
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

            var result = input.FilterUniqueAndAgeBiggerThan20();

            CollectionAssert.AreEqual(expectedResult, result);
        }

        #endregion
    }
}
