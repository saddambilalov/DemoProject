using Btn.Engine.ComparatorExtensions;
using Btn.Infracture.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Btn.UnitTests
{
    [TestClass]
    public class BtnTests
    {
        #region Pass

        [TestMethod]
        public void One_Of_Btn_Trees_Is_Null_Should_Pass()
        {
            var firstBtn = new BTN
            {
                Val = 1,
                Left = new BTN
                {
                    Val = 2
                },
                Right = new BTN
                {
                    Val = 3
                }
            };

            firstBtn.IsTreeEqualTo(null);
        }

        [TestMethod]
        public void Both_Of_Btn_Trees_Is_Null_Should_Pass()
        {
            ((BTN)null).IsTreeEqualTo(null);
        }

        //http://lcm.csa.iisc.ernet.in/dsa/img151.gif
        [TestMethod]
        public void Compare_Equal_BTN_Trees_Should_Pass()
        {
            var firstBtn = new BTN
            {
                Val = 1,
                Left = new BTN
                {
                    Val = 2,
                    Left = new BTN
                    {
                        Val = 4,
                        Left = new BTN
                        {
                            Val = 8
                        },
                        Right = new BTN
                        {
                            Val = 9
                        }
                    },
                    Right = new BTN
                    {
                        Val = 5
                    }
                },
                Right = new BTN
                {
                    Val = 3,
                    Left = new BTN
                    {
                        Val = 6
                    },
                    Right = new BTN
                    {
                        Val = 7
                    }
                }
            };

            var secondBtn = new BTN
            {
                Val = 1,
                Left = new BTN
                {
                    Val = 2,
                    Left = new BTN
                    {
                        Val = 4,
                        Left = new BTN
                        {
                            Val = 8
                        },
                        Right = new BTN
                        {
                            Val = 9
                        }
                    },
                    Right = new BTN
                    {
                        Val = 5
                    }
                },
                Right = new BTN
                {
                    Val = 3,
                    Left = new BTN
                    {
                        Val = 6
                    },
                    Right = new BTN
                    {
                        Val = 7
                    }
                }
            };

            Assert.IsTrue(firstBtn.IsTreeEqualTo(secondBtn));
        }

        //https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Binary_search_tree.svg/2000px-Binary_search_tree.svg.png
        [TestMethod]
        public void Compare_Equal_BTN_Trees_Should_Pass_1()
        {
            var firstBtn = new BTN
            {
                Val = 8,
                Left = new BTN
                {
                    Val = 3,
                    Left = new BTN
                    {
                        Val = 1
                    },
                    Right = new BTN
                    {
                        Val = 6,
                        Left = new BTN
                        {
                            Val = 4
                        },
                        Right = new BTN
                        {
                            Val = 7
                        }
                    }
                },
                Right = new BTN
                {
                    Val = 10,
                    Right = new BTN
                    {
                        Val = 14,
                        Right = new BTN
                        {
                            Val = 13
                        }
                    }
                }
            };

            var secondBtn = new BTN
            {
                Val = 8,
                Left = new BTN
                {
                    Val = 3,
                    Left = new BTN
                    {
                        Val = 1
                    },
                    Right = new BTN
                    {
                        Val = 6,
                        Left = new BTN
                        {
                            Val = 4
                        },
                        Right = new BTN
                        {
                            Val = 7
                        }
                    }
                },
                Right = new BTN
                {
                    Val = 10,
                    Right = new BTN
                    {
                        Val = 14,
                        Right = new BTN
                        {
                            Val = 13
                        }
                    }
                }
            };

            Assert.IsTrue(firstBtn.IsTreeEqualTo(secondBtn));
        }

        #endregion


        #region Fail

        [TestMethod]
        public void The_Second_Tree_Do_Not_Have_Right_Compared_To_The_First_Should_Fail()
        {
            var firstBtn = new BTN
            {
                Val = 1,
                Left = new BTN
                {
                    Val = 2,
                    Left = new BTN
                    {
                        Val = 4
                    },
                    Right = new BTN
                    {
                        Val = 5
                    }
                },
                Right = new BTN
                {
                    Val = 3,
                    Left = new BTN
                    {
                        Val = 6
                    },
                    Right = new BTN
                    {
                        Val = 7
                    }
                }
            };

            var secondBtn = new BTN
            {
                Val = 1,
                Left = new BTN
                {
                    Val = 2,
                    Left = new BTN
                    {
                        Val = 4
                    }
                },
                Right = new BTN
                {
                    Val = 3,
                    Left = new BTN
                    {
                        Val = 6
                    }
                }
            };

            Assert.IsTrue(firstBtn.IsTreeEqualTo(secondBtn));
        }

        [TestMethod]
        public void The_Second_Tree_Have_Different_Elements_In_The_Right_Compared_To_The_First_Should_Fail()
        {
            var firstBtn = new BTN
            {
                Val = 1,
                Left = new BTN
                {
                    Val = 2,
                    Left = new BTN
                    {
                        Val = 4
                    },
                    Right = new BTN
                    {
                        Val = 5
                    }
                },
                Right = new BTN
                {
                    Val = 3,
                    Left = new BTN
                    {
                        Val = 6
                    },
                    Right = new BTN
                    {
                        Val = 7
                    }
                }
            };

            var secondBtn = new BTN
            {
                Val = 1,
                Left = new BTN
                {
                    Val = 2,
                    Left = new BTN
                    {
                        Val = 4
                    },
                    Right = new BTN
                    {
                        Val = 10
                    }
                },
                Right = new BTN
                {
                    Val = 3,
                    Left = new BTN
                    {
                        Val = 6
                    },
                    Right = new BTN
                    {
                        Val = 12
                    }
                }
            };

            Assert.IsTrue(firstBtn.IsTreeEqualTo(secondBtn));
        }

        #endregion
    }
}
