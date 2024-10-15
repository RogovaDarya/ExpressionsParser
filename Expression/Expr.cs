namespace Expressions;

public static class Expr
{
    private static string _expression = "";
    private static int _index = 0;

    public static bool ParseExpr(string expression)
    {
        _index = 0;
        _expression = expression;
        bool valid = Parse_expression();
        return valid && _index == _expression.Length;
    }

    private static bool Parse_expression()
    {
        if (_index >= _expression.Length) return false;

        SkipWhitespace();

        // Обработка унарного минуса
        if (_expression[_index] == '-')
        {
            _index++;
            if (!Parse_expression()) return false;
            return true;
        }

        SkipWhitespace();

        // Обработка чисел и скобок
        if (Char.IsDigit(_expression[_index]))
        {
            ParseNumber();
        }
        else if (_expression[_index] == '(')
        {
            _index++;
            if (!Parse_expression()) return false;
            if (_index >= _expression.Length || _expression[_index] != ')') return false;
            _index++;
        }
        else
        {
            return false;
        }

        // Пропуск пробелов
        SkipWhitespace();

        // Обработка операторов
        if (_index < _expression.Length && IsOperator(_expression[_index]))
        {
            _index++;
            return Parse_expression();
        }

        return true;
    }

    private static bool IsOperator(char v) 
        => v is '+' or '-' or '*' or '/';

    private static void ParseNumber()
    {
        while (_index < _expression.Length && Char.IsDigit(_expression[_index]))
        {
            ++_index;
        }
    }

    private static void SkipWhitespace()
    {
        while (_index < _expression.Length && Char.IsWhiteSpace(_expression[_index]))
        {
            ++_index;
        }
    }
}
