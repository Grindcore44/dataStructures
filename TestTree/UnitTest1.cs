//using Xunit;

//namespace TestTree
//{
//    public class UnitTest1ff
//    {
//        [Fact]
//        public void AddNewValueTest()
//        {
//            // arrenge
//            BinaryNodeTree<int> node = new BinaryNodeTree<int>(5);
//            int expectedCurrentRight = 13;
//            int expectedCurrentLeft = 2;

//            // act
//            node.AddNewValue(expectedCurrentRight);
//            node.AddNewValue(expectedCurrentLeft);
//            int actualCurrentRight = node.RightBranch.nodeValue;
//            int actualCurrentLeft = node.LeftBranch.nodeValue;

//            //assert
//            Assert.Equal(expectedCurrentRight, actualCurrentRight);
//            Assert.Equal(expectedCurrentLeft, actualCurrentLeft);
//        }

//        [Fact]

//        public void SearchNodeTest()
//        {
//            //arrange
//            BinaryNodeTree<int> node = new BinaryNodeTree<int>(20);
//            int valueFound = 35;
//            int valueNoFound = 333;
//            node.AddNewValue(35);
//            node.AddNewValue(56);
//            node.AddNewValue(3);
//            node.AddNewValue(5);
//            node.AddNewValue(19);
//            node.AddNewValue(14);

//            //act
//            bool found = node.SearchNode(valueFound);
//            bool noFound = node.SearchNode(valueNoFound);

//            //assert
//            Assert.True(found);
//            Assert.False(noFound);
//        }


//    }
    
//}