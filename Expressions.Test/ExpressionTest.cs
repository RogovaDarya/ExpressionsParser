namespace Expressions.Test;

[TestFixture]
public class ExpressionTest
{
    [TestCase("(1 + 1)", ExpectedResult = true)]
    [TestCase("(2+1)*2", ExpectedResult = true)]
    [TestCase("(2)", ExpectedResult = true)]
    [TestCase("3+(4*5)-2", ExpectedResult = true)]
    [TestCase("((10/(5+5))*(6-4))", ExpectedResult = true)]
    [TestCase("(7+8*(9-3))/(2+1)", ExpectedResult = true)]
    [TestCase("(2+(3*(4-2)))", ExpectedResult = true)]
    [TestCase("(10/(5+(1*2)))", ExpectedResult = true)]
    [TestCase("((2+3)*(4/2))", ExpectedResult = true)]
    [TestCase("((6-2)*(8+3))/(4+1)", ExpectedResult = true)]
    [TestCase("(10*(2+3))/5", ExpectedResult = true)]
    [TestCase("(15/(3+2))*(4-2)", ExpectedResult = true)]
    [TestCase("(9-(4+5))/2", ExpectedResult = true)]
    [TestCase("(7*(8-3))+4", ExpectedResult = true)]
    [TestCase("(6/(2+1))*(9-4)", ExpectedResult = true)]
    [TestCase("((2*3)+(4-2))", ExpectedResult = true)]
    [TestCase("(12+(5*2))/7", ExpectedResult = true)]
    [TestCase("(10-(3+2))*(4+1)", ExpectedResult = true)]
    [TestCase("((4+6)*(8/2))/(5-1)", ExpectedResult = true)]
    [TestCase("(7-(2+3))*(9+1)", ExpectedResult = true)]
    [TestCase("-2", ExpectedResult = true)]
    [TestCase("-(2)", ExpectedResult = true)]
    [TestCase("-(1+2)", ExpectedResult = true)]
    [TestCase("-2+1", ExpectedResult = true)]
    [TestCase("-2-(2)", ExpectedResult = true)]
    [TestCase("122 + 1", ExpectedResult = true)]
    [TestCase("122 + 1 ", ExpectedResult = true)]
    [TestCase(" 122 + 1", ExpectedResult = true)]
    [TestCase("122 + (1 ) ", ExpectedResult = true)]
    [TestCase("122 + ( 1)", ExpectedResult = true)]
    [TestCase("122 + ( 1 )", ExpectedResult = true)]
    [TestCase("122 + (   1  )", ExpectedResult = true)]
    [TestCase("122 + (   1)", ExpectedResult = true)]
    [TestCase("   122 + ( 1)", ExpectedResult = true)]
    public bool ExpressionTestTrue (string expression)
    {
        return Expr.ParseExpr(expression);
    }

    [TestCase("((", ExpectedResult = false)]
    [TestCase("(2)+", ExpectedResult = false)]
    [TestCase("2+)+3", ExpectedResult = false)]
    [TestCase("(5*(6-3)", ExpectedResult = false)]
    [TestCase("((4/2))*(3+)", ExpectedResult = false)]
    [TestCase("(3+4)*5)-2", ExpectedResult = false)]
    [TestCase("(2*(3+(4-2))", ExpectedResult = false)]
    [TestCase("(10/(5+2)*(6-4", ExpectedResult = false)]
    [TestCase("(3/0))", ExpectedResult = false)]
    [TestCase("((6-2)*(8+))/5", ExpectedResult = false)]
    [TestCase("((10*(2+3))/5", ExpectedResult = false)]
    [TestCase("((15/(3+2)*(4-2)", ExpectedResult = false)]
    [TestCase("(9-(4+5)/2", ExpectedResult = false)]
    [TestCase("7*(8-3))+", ExpectedResult = false)]
    [TestCase("(6/(2+1)*(9-", ExpectedResult = false)]
    [TestCase("(2*3)+(4-)", ExpectedResult = false)]
    [TestCase("10-(3+2)*(4+", ExpectedResult = false)]
    [TestCase("(7-(2+3)*(9+", ExpectedResult = false)]
    public bool ExpressionTestFalse(string expression)
    {
        return Expr.ParseExpr(expression);
    }
}
