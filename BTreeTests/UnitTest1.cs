using Btree;
using Xunit;

//arrange

// act

// assert

namespace BTreeTests;

public class UnitTest1
{
    [Fact]

    public void ConstructorNodeTest()
    {
        // arrenge
        int value = 45;
        var node = new NodeBtree<int>(3, value);
        var expectedCurrent = value;
        // act
        var actualCurrent = node.CellBtree.Value;

        //assert
        Assert.Equal(expectedCurrent, actualCurrent);
    }

    [Fact]

    public void AddFirstCellTest()
    {
        //arrange
        var secondCell = 45;
        int valueFirst = 35;
        var firstCell = new CellBTree<int>(valueFirst);
        NodeBtree<int> node = new NodeBtree<int>(3, secondCell);

        // act
        CellBTree<int> newNodeHead = node.CellBtree.AddFirstCell(firstCell);
        var actualCurrent = newNodeHead.Value;
        var expectedCurrent = valueFirst;
        // assert
        Assert.Equal(expectedCurrent, actualCurrent);
    }

    [Fact]

    public void AddLastCellTest()
    {
        // arrange 
        int valueFirstCell = 35;
        int valueSecondCell = 45;
        int valueFhirdCell = 55;
        var firstCell = new CellBTree<int>(valueFirstCell);
        var secondCell = new CellBTree<int>(valueSecondCell);
        var fhirdCell = new CellBTree<int>(valueFhirdCell);
        NodeBtree<int> node = new NodeBtree<int>(3, secondCell);

        // act
        CellBTree<int> newNodeHead = node.CellBtree.AddFirstCell(firstCell);
        newNodeHead.AddLastCell(fhirdCell);
        var actualCurrent = newNodeHead.NextCell.NextCell.Value;
        var expectedValue = valueFhirdCell;

        // assert
        Assert.Equal(expectedValue, actualCurrent);
    }

    [Fact]

    public void AddCellByIndexTest()
    {
        // arrange
        int valueFirstCell = 35;
        int valueSecondCell = 45;
        int valueFhirdCell = 55;
        int valueFourthCell = 65;
        var expectedCurrent1 = valueFirstCell;
        var expectedCurrent2 = valueSecondCell;
        var expectedCurrent3 = valueFhirdCell;
        var expectedCurrent4 = valueFourthCell;
        CellBTree<int> firstCell = new CellBTree<int>(valueFirstCell);
        CellBTree<int> secondCell = new CellBTree<int>(valueSecondCell);
        CellBTree<int> fhirdCell = new CellBTree<int>(valueFhirdCell);
        CellBTree<int> fourthCell = new CellBTree<int>(valueFourthCell);
        CellBTree<int> cell = new CellBTree<int>(valueSecondCell);

        // act
        cell = cell.AddCellByIndex(firstCell, 0);
        cell.AddLastCell(fourthCell);
        cell = cell.AddCellByIndex(fhirdCell, 2);
        var actualCurrent1 = cell.Value;
        var actualCurrent2 = cell.NextCell.Value;
        var actualCurrent3 = cell.NextCell.NextCell.Value;
        var actualCurrent4 = cell.NextCell.NextCell.NextCell.Value;
        // assert
        Assert.Equal(expectedCurrent1, actualCurrent1);
        Assert.Equal(expectedCurrent2, actualCurrent2);
        Assert.Equal(expectedCurrent3, actualCurrent3);
        Assert.Equal(expectedCurrent4, actualCurrent4);
    }


    [Fact]

    public void AddNewValueInNotFullNodeTest()
    {
        // arrange
        int valueFirstCell = 35;
        int valueSecondCell = 45;
        int valueFhirdCell = 55;
        int valueFourthCell = 65;
        int valueFifthCell = 75;
        CellBTree<int> firstCell = new CellBTree<int>(valueFirstCell);
        CellBTree<int> secondCell = new CellBTree<int>(valueSecondCell);
        CellBTree<int> fhirdCell = new CellBTree<int>(valueFhirdCell);
        CellBTree<int> fourthCell = new CellBTree<int>(valueFourthCell);
        CellBTree<int> fifthCell = new CellBTree<int>(valueFifthCell);
        NodeBtree<int> node = new NodeBtree<int>(3, secondCell);
        node.CellBtree.AddLastCell(fourthCell);

        var expectedCurrent1 = valueFirstCell;
        var expectedCurrent2 = valueSecondCell;
        var expectedCurrent3 = valueFhirdCell;
        var expectedCurrent4 = valueFourthCell;
        var expectedCurrent5 = valueFifthCell;

        // act
        node.AddNewCellInNotFullNode(firstCell);
        node.AddNewCellInNotFullNode(fhirdCell);
        node.AddNewCellInNotFullNode(fifthCell);

        var actualCurrent1 = node.CellBtree.Value;
        var actualCurrent2 = node.CellBtree.NextCell.Value;
        var actualCurrent3 = node.CellBtree.NextCell.NextCell.Value;
        var actualCurrent4 = node.CellBtree.NextCell.NextCell.NextCell.Value;
        var actualCurrent5 = node.CellBtree.NextCell.NextCell.NextCell.NextCell.Value;

        // assert
        Assert.Equal(expectedCurrent1, actualCurrent1);
        Assert.Equal(expectedCurrent2, actualCurrent2);
        Assert.Equal(expectedCurrent3, actualCurrent3);
        Assert.Equal(expectedCurrent4, actualCurrent4);
        Assert.Equal(expectedCurrent5, actualCurrent5);
    }

    [Fact]
    public void AddNewValueInNotFullNodeTest2()
    {
        // arrange
        int valueFirstCell = 35;
        int valueSecondCell = 45;
        int valueFhirdCell = 55;
        int valueFourthCell = 65;
        int valueFifthCell = 75;
        CellBTree<int> firstCell = new CellBTree<int>(valueFirstCell);
        CellBTree<int> secondCell = new CellBTree<int>(valueSecondCell);
        CellBTree<int> fhirdCell = new CellBTree<int>(valueFhirdCell);
        CellBTree<int> fourthCell = new CellBTree<int>(valueFourthCell);
        CellBTree<int> fifthCell = new CellBTree<int>(valueFifthCell);
        NodeBtree<int> node = new NodeBtree<int>(3, firstCell);
        var expectedCurrent1 = valueFirstCell;
        var expectedCurrent2 = valueSecondCell;
        var expectedCurrent3 = valueFhirdCell;
        var expectedCurrent4 = valueFourthCell;
        var expectedCurrent5 = valueFifthCell;

        // act
        node.AddNewCellInNotFullNode(fifthCell);
        node.AddNewCellInNotFullNode(fourthCell);
        node.AddNewCellInNotFullNode(fhirdCell);
        node.AddNewCellInNotFullNode(secondCell);
        node.AddNewCellInNotFullNode(fifthCell);
        var actualCurrent1 = node.CellBtree.Value;
        var actualCurrent2 = node.CellBtree.NextCell.Value;
        var actualCurrent3 = node.CellBtree.NextCell.NextCell.Value;
        var actualCurrent4 = node.CellBtree.NextCell.NextCell.NextCell.Value;
        var actualCurrent5 = node.CellBtree.NextCell.NextCell.NextCell.NextCell.Value;
        var actualCurrent6 = node.CellBtree.NextCell.NextCell.NextCell.NextCell.NextCell.Value;
        // assert
        Assert.Equal(expectedCurrent1, actualCurrent1);
        Assert.Equal(expectedCurrent2, actualCurrent2);
        Assert.Equal(expectedCurrent3, actualCurrent3);
        Assert.Equal(expectedCurrent4, actualCurrent4);
        Assert.Equal(expectedCurrent5, actualCurrent5);
        Assert.Equal(expectedCurrent5, actualCurrent6);
    }

    [Fact]

    public void CellCountTest()
    {
        //arrange
        int valueFirstCell = 35;
        int valueSecondCell = 45;
        int valueFhirdCell = 55;
        int valueFourthCell = 65;
        int valueFifthCell = 75;
        CellBTree<int> firstCell = new CellBTree<int>(valueFirstCell);
        CellBTree<int> secondCell = new CellBTree<int>(valueSecondCell);
        CellBTree<int> fhirdCell = new CellBTree<int>(valueFhirdCell);
        CellBTree<int> fourthCell = new CellBTree<int>(valueFourthCell);
        CellBTree<int> fifthCell = new CellBTree<int>(valueFifthCell);
        NodeBtree<int> node = new NodeBtree<int>(6, firstCell);
        node.CellBtree.AddLastCell(secondCell);
        node.CellBtree.AddLastCell(fhirdCell);
        node.CellBtree.AddLastCell(fourthCell);
        node.CellBtree.AddLastCell(fifthCell);
        var expectedCurrent = 5;

        //act
        int actualCurrent = node.CellCount();

        //assert
        Assert.Equal(expectedCurrent, actualCurrent);
    }

    [Fact]
    public void GetCellByIndexTest()
    {
        //arrange
        int valueFirstCell = 35;
        int valueSecondCell = 45;
        int valueFhirdCell = 55;
        int valueFourthCell = 65;
        int valueFifthCell = 75;
        CellBTree<int> firstCell = new CellBTree<int>(valueFirstCell);
        CellBTree<int> secondCell = new CellBTree<int>(valueSecondCell);
        CellBTree<int> fhirdCell = new CellBTree<int>(valueFhirdCell);
        CellBTree<int> fourthCell = new CellBTree<int>(valueFourthCell);
        CellBTree<int> fifthCell = new CellBTree<int>(valueFifthCell);
        NodeBtree<int> node = new NodeBtree<int>(6, firstCell);
        node.AddNewCellInNotFullNode(secondCell);
        node.AddNewCellInNotFullNode(fhirdCell);
        node.AddNewCellInNotFullNode(fourthCell);
        node.AddNewCellInNotFullNode(fifthCell);

        int expectedCurrent1 = valueFirstCell;
        int expectedCurrent2 = valueSecondCell;
        int expectedCurrent3 = valueFhirdCell;
        int expectedCurrent4 = valueFourthCell;
        int expectedCurrent5 = valueFifthCell;
        //act 
        CellBTree<int> actualCurrent1 = node.GetCellByIndex(0);
        CellBTree<int> actualCurrent2 = node.GetCellByIndex(1);
        CellBTree<int> actualCurrent3 = node.GetCellByIndex(2);
        CellBTree<int> actualCurrent4 = node.GetCellByIndex(3);
        CellBTree<int> actualCurrent5 = node.GetCellByIndex(4);

        //assert 
        Assert.Equal(expectedCurrent1, actualCurrent1.Value);
        Assert.Equal(expectedCurrent2, actualCurrent2.Value);
        Assert.Equal(expectedCurrent3, actualCurrent3.Value);
        Assert.Equal(expectedCurrent4, actualCurrent4.Value);
        Assert.Equal(expectedCurrent5, actualCurrent5.Value);
    }

    [Fact]

    public void DeleteNotHeadCellByIndex()
    {
        //arrange
        int valueFirstCell = 35;
        int valueSecondCell = 45;
        int valueFhirdCell = 55;
        int valueFourthCell = 65;
        int valueFifthCell = 75;
        CellBTree<int> firstCell = new CellBTree<int>(valueFirstCell);
        CellBTree<int> secondCell = new CellBTree<int>(valueSecondCell);
        CellBTree<int> fhirdCell = new CellBTree<int>(valueFhirdCell);
        CellBTree<int> fourthCell = new CellBTree<int>(valueFourthCell);
        CellBTree<int> fifthCell = new CellBTree<int>(valueFifthCell);
        NodeBtree<int> node = new NodeBtree<int>(6, firstCell);
        node.CellBtree.AddLastCell(secondCell);
        node.CellBtree.AddLastCell(fhirdCell);
        node.CellBtree.AddLastCell(fourthCell);
        node.CellBtree.AddLastCell(fifthCell);
        var expextedCurrent = node.CellBtree.NextCell.NextCell.NextCell.NextCell;
        //act
        node.CellBtree.DeleteNotHeadCellByIndex(3);
        var actualCurrent = node.CellBtree.NextCell.NextCell.NextCell;
        //assert
        Assert.Equal(expextedCurrent, actualCurrent);
    }

    [Fact]
    public void DeleteNotHeadCellByIndex2()
    {
        //arrange
        int valueFirstCell = 35;
        int valueSecondCell = 45;
        int valueFhirdCell = 55;
        int valueFourthCell = 65;
        int valueFifthCell = 75;
        CellBTree<int> firstCell = new CellBTree<int>(valueFirstCell);
        CellBTree<int> secondCell = new CellBTree<int>(valueSecondCell);
        CellBTree<int> fhirdCell = new CellBTree<int>(valueFhirdCell);
        CellBTree<int> fourthCell = new CellBTree<int>(valueFourthCell);
        CellBTree<int> fifthCell = new CellBTree<int>(valueFifthCell);
        NodeBtree<int> node = new NodeBtree<int>(6, firstCell);
        node.CellBtree.AddLastCell(secondCell);
        node.CellBtree.AddLastCell(fhirdCell);
        node.CellBtree.AddLastCell(fourthCell);
        node.CellBtree.AddLastCell(fifthCell);
        var expextedCurrent = node.CellBtree.NextCell.NextCell;
        //act
        node.CellBtree.DeleteNotHeadCellByIndex(1);
        var actualCurrent = node.CellBtree.NextCell;
        //assert
        Assert.Equal(expextedCurrent, actualCurrent);
    }

    [Fact]

    public void DeleteCellInNodeTest()
    {
        //arrange
        int valueFirstCell = 35;
        int valueSecondCell = 45;
        int valueFhirdCell = 55;
        int valueFourthCell = 65;
        int valueFifthCell = 75;
        CellBTree<int> firstCell = new CellBTree<int>(valueFirstCell);
        CellBTree<int> secondCell = new CellBTree<int>(valueSecondCell);
        CellBTree<int> fhirdCell = new CellBTree<int>(valueFhirdCell);
        CellBTree<int> fourthCell = new CellBTree<int>(valueFourthCell);
        CellBTree<int> fifthCell = new CellBTree<int>(valueFifthCell);
        NodeBtree<int> node = new NodeBtree<int>(6, firstCell);
        node.CellBtree.AddLastCell(secondCell);
        node.CellBtree.AddLastCell(fhirdCell);
        node.CellBtree.AddLastCell(fourthCell);
        node.CellBtree.AddLastCell(fifthCell);
        var expextedCurrent = node.CellBtree.NextCell.NextCell.Value;
        var expextedCurrent2 = node.CellBtree.NextCell.NextCell.NextCell.NextCell.Value;
        //act
        node.DeleteCellInNode(valueSecondCell);
        var actualCurrent = node.CellBtree.NextCell.Value;
        node.DeleteCellInNode(valueFourthCell);
        var actualCurrent2 = node.CellBtree.NextCell.NextCell.Value;
        //assert
        Assert.Equal(expextedCurrent, actualCurrent);
        Assert.Equal(expextedCurrent2, actualCurrent2);
    }

    [Fact]
    public void DeleteCellInNodeTest2()
    {
        //arrange
        int valueFirstCell = 35;
        int valueSecondCell = 45;
        int valueFhirdCell = 55;
        int valueFourthCell = 65;
        int valueFifthCell = 75;
        CellBTree<int> firstCell = new CellBTree<int>(valueFirstCell);
        CellBTree<int> secondCell = new CellBTree<int>(valueSecondCell);
        CellBTree<int> fhirdCell = new CellBTree<int>(valueFhirdCell);
        CellBTree<int> fourthCell = new CellBTree<int>(valueFourthCell);
        CellBTree<int> fifthCell = new CellBTree<int>(valueFifthCell);
        NodeBtree<int> node = new NodeBtree<int>(6, firstCell);
        node.CellBtree.AddLastCell(secondCell);
        node.CellBtree.AddLastCell(fhirdCell);
        node.CellBtree.AddLastCell(fourthCell);
        node.CellBtree.AddLastCell(fifthCell);
        var expextedCurrent = node.CellBtree.NextCell.Value;
        //act
        node.DeleteCellInNode(valueFirstCell);
        var actualCurrent = node.CellBtree.Value;
        node.DeleteCellInNode(valueFifthCell);
        //assert
        Assert.Equal(expextedCurrent, actualCurrent);
        Assert.Null(node.CellBtree.NextCell.NextCell.NextCell);

    }

    [Fact]

    public void MedianValueTest()
    {
        //arrange
        int valueFirstCell = 35;
        int valueSecondCell = 45;
        int valueFhirdCell = 55;
        int valueFourthCell = 65;
        int valueFifthCell = 75;
        int valueSixthCell = 85;
        int newValue = 44;
        CellBTree<int> newCell = new CellBTree<int>(newValue);
        CellBTree<int> firstCell = new CellBTree<int>(valueFirstCell);
        CellBTree<int> secondCell = new CellBTree<int>(valueSecondCell);
        CellBTree<int> fhirdCell = new CellBTree<int>(valueFhirdCell);
        CellBTree<int> fourthCell = new CellBTree<int>(valueFourthCell);
        CellBTree<int> fifthCell = new CellBTree<int>(valueFifthCell);
        CellBTree<int> sixthCell = new CellBTree<int>(valueSixthCell);
        NodeBtree<int> node = new NodeBtree<int>(7, firstCell);
        node.AddNewCellInNotFullNode(secondCell);
        node.AddNewCellInNotFullNode(fhirdCell);
        node.AddNewCellInNotFullNode(fourthCell);
        node.AddNewCellInNotFullNode(fifthCell);
        node.AddNewCellInNotFullNode(sixthCell);
        var expectedCurrent = valueFhirdCell;

        //act
        CellBTree<int> cellBTree = node.GetMedianValue(newCell);
        var actualCurrent = cellBTree.Value;
        //assert
        Assert.Equal(expectedCurrent, actualCurrent);
    }

    [Fact]

    public void MedianValueTest2()
    {
        //arrange
        int valueFirstCell = 35;
        int valueSecondCell = 45;
        int valueFhirdCell = 55;
        int valueFourthCell = 65;
        int valueFifthCell = 75;
        int newValue = 55;
        CellBTree<int> newCell = new CellBTree<int>(newValue);
        CellBTree<int> firstCell = new CellBTree<int>(valueFirstCell);
        CellBTree<int> secondCell = new CellBTree<int>(valueSecondCell);
        CellBTree<int> fhirdCell = new CellBTree<int>(valueFhirdCell);
        CellBTree<int> fourthCell = new CellBTree<int>(valueFourthCell);
        CellBTree<int> fifthCell = new CellBTree<int>(valueFifthCell);
        NodeBtree<int> node = new NodeBtree<int>(7, firstCell);
        node.AddNewCellInNotFullNode(secondCell);
        node.AddNewCellInNotFullNode(fhirdCell);
        node.AddNewCellInNotFullNode(fourthCell);
        node.AddNewCellInNotFullNode(fifthCell);
        var expectedCurrent = newValue;

        //act
        CellBTree<int> cellBTree = node.GetMedianValue(newCell);
        var actualCurrent = cellBTree.Value;
        //assert
        Assert.Equal(expectedCurrent, actualCurrent);
    }

    //public void AddNewValueInNodeTest()
    //{
    //    // arrange
    //    int valueFirstCell = 35;
    //    int valueSecondCell = 45;
    //    int valueFhirdCell = 55;
    //    int valueFourthCell = 65;
    //    int valueFifthCell = 75;
    //    int newValue = 55;
    //    CellBTree<int> newCell = new CellBTree<int>(newValue);
    //    CellBTree<int> firstCell = new CellBTree<int>(valueFirstCell);
    //    CellBTree<int> secondCell = new CellBTree<int>(valueSecondCell);
    //    CellBTree<int> fhirdCell = new CellBTree<int>(valueFhirdCell);
    //    CellBTree<int> fourthCell = new CellBTree<int>(valueFourthCell);
    //    CellBTree<int> fifthCell = new CellBTree<int>(valueFifthCell);
    //    NodeBtree<int> node = new NodeBtree<int>(7, firstCell);
    //    node.AddNewCellInNotFullNode(secondCell);
    //    node.AddNewCellInNotFullNode(fhirdCell);
    //    node.AddNewCellInNotFullNode(fourthCell);
    //    node.AddNewCellInNotFullNode(fifthCell);

    //    //act
    //    node.AddNewValueInNode(newCell);


    //    //assert

    //}

    [Fact]
    public void DivideNodeTest()
    {
        //arrange
        int valueFirstCell = 35;
        int valueSecondCell = 45;
        int valueFhirdCell = 55;
        int valueFourthCell = 65;
        int valueFifthCell = 75;
        int newValue = 55;
        CellBTree<int> newCell = new CellBTree<int>(newValue);
        CellBTree<int> firstCell = new CellBTree<int>(valueFirstCell);
        CellBTree<int> secondCell = new CellBTree<int>(valueSecondCell);
        CellBTree<int> fhirdCell = new CellBTree<int>(valueFhirdCell);
        CellBTree<int> fourthCell = new CellBTree<int>(valueFourthCell);
        CellBTree<int> fifthCell = new CellBTree<int>(valueFifthCell);
        NodeBtree<int> node = new NodeBtree<int>(6, firstCell);
        node.AddNewCellInNotFullNode(secondCell);
        node.AddNewCellInNotFullNode(fhirdCell);
        node.AddNewCellInNotFullNode(fourthCell);
        node.AddNewCellInNotFullNode(fifthCell);
        var expectedCurrent1 = valueFirstCell;
        var expectedCurrent2 = valueSecondCell;
        var expectedCurrent3 = valueFhirdCell;
        var expectedCurrent4 = valueFourthCell;
        var expectedCurrent5 = valueFifthCell;
        //act
        var resultCell = node.DivideNode(newCell);
        var actualCurrentLefttNode1 = resultCell.LeftNode.CellBtree.Value;
        var actualCurrentLefttNode2 = resultCell.LeftNode.CellBtree.NextCell.Value;
        var actualCurrentRightNode1 = resultCell.RightNode.CellBtree.Value;
        var actualCurrentRightNode2 = resultCell.RightNode.CellBtree.NextCell.Value;
        var actualCurrentRightNode3 = resultCell.RightNode.CellBtree.NextCell.NextCell.Value;
        //assert
        Assert.NotNull(resultCell.LeftNode);
        Assert.NotNull(resultCell.RightNode);
        Assert.Equal(expectedCurrent1, actualCurrentLefttNode1);
        Assert.Equal(expectedCurrent2, actualCurrentLefttNode2);
        Assert.Equal(expectedCurrent3, actualCurrentRightNode1);
        Assert.Equal(expectedCurrent4, actualCurrentRightNode2);
        Assert.Equal(expectedCurrent5, actualCurrentRightNode3);
    }
}

