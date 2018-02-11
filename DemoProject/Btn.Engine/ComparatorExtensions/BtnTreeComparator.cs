using Btn.Infracture.Models;

namespace Btn.Engine.ComparatorExtensions
{
   public static class BtnTreeComparator
    {
        public static bool IsTreeEqualTo(this BTN firstTree, BTN secondTree)
        {
            if (firstTree == null && secondTree == null)
            {
                return true;
            }

            if (firstTree == null || secondTree == null)
            {
                return false;
            }

            if (firstTree.Val != secondTree.Val)
            {
                return false;
            }

            return IsTreeEqualTo(firstTree.Left, secondTree.Left) && IsTreeEqualTo(firstTree.Right, secondTree.Right);
        }
    }
}
