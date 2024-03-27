namespace ULSolutions.Domain;

public interface IExpression
{    
    Task<int> Calculate(Expression expr);

}
