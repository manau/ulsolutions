using MediatR;
namespace ULSolutions.Application.Commands;
using System.Text.RegularExpressions;

public class CalculateCommandHandler : IRequestHandler<CalculateCommand, double>
{
    public  Task<double> Handle(CalculateCommand request, CancellationToken cancellationToken)
    {
        // Implement your logic to calculate based on the expression in the command
        double result = CalculateExpression(request.Expression);
        return Task.FromResult(result);
    }

    public double CalculateExpression(string expression)
    {
        string padrao = @"(\d+|\+|\-|\*|\/)";
        
        // Encontrar todos os números e operadores usando a expressão regular
        MatchCollection matches = Regex.Matches(expression, padrao);
        
        // Lista para armazenar os números e operadores separados
        List<string> elementos = new List<string>();

        // Adicionar os números e operadores à lista
        foreach (Match match in matches)
        {
            elementos.Add(match.Value);
        }

        // Imprimir os números e operadores separados
        double fat1 =0;
        double fat2 =0;
        string oper = "1";        
        string operatu = "+";
        string operant = "+";
        foreach (string elemento in elementos)
        {            
            if (isNumber(elemento))
                {
                    if (oper=="1")
                    {
                        if (operatu=="*")
                            fat1*=double.Parse(elemento);
                        else if (operatu=="/")
                            fat1/=double.Parse(elemento);
                        else if (operatu=="+")
                            fat1+=double.Parse(elemento); 
                        else if (operatu=="-")
                            fat1-=double.Parse(elemento);   
                    }
                    else
                    {
                        if (operatu=="*")
                            fat2*=double.Parse(elemento);
                        else if (operatu=="/")
                            fat2/=double.Parse(elemento);
                        else if (operatu=="+")
                            fat2+=double.Parse(elemento); 
                        else if (operatu=="-")
                            fat2-=double.Parse(elemento); 
                    }
                }
            else
            {
                operatu = elemento;
                if(elemento=="+" || elemento=="-")
                {

                    if (oper=="2")
                    {
                        // if (operant=="+")
                        //     fat1+=fat2;
                        // else if (operant=="-")
                        //     fat1-=fat2;
                        fat1+=fat2;
                        fat2=0;
                        operant="+";
                        //oper="1";
                    }
                    else
                        oper="2";
                    operant=operatu;
                }
                else    
                {

                }
                
            }
        }
        double final=fat1+fat2;
        // if (operatu=="+")
        //     final=fat1+fat2;
        // else if (operant=="-")
        //     final=fat1-fat2;
        // else if (operant!="-")
        //     final=fat1+fat2;

        return final;
    }
    private bool isNumber(string elemento)
    {
        switch (elemento)
        {
            case "+":
            case "-":
            case "*":
            case "/":
                return false;
            default:
                return true;
        }
    }
}
