using ULSolutions.Application.Commands;
public class CalculateExpressionTest
{
    [Fact]
    public async void Calculate_ReturnsCorrectResult()
    {
        var handle = new CalculateCommandHandler();
        
        var command = new CalculateCommand{  Expression = "4+5*2" };
        var task = handle.Handle(command, CancellationToken.None);
        double result = await task;
        Assert.Equal(14, result);

        command = new CalculateCommand{  Expression = "4+5/2" };
        task = handle.Handle(command, CancellationToken.None);
        result = await task;
        Assert.Equal(6.5, result);

        command = new CalculateCommand{  Expression = "4+5/2-1" };
        task = handle.Handle(command, CancellationToken.None);
        result = await task;
        Assert.Equal(5.5, result);


    }

    [Fact]
     public async void Calculate_BasicOperations()
    {
        var handle = new CalculateCommandHandler();
        
        var command = new CalculateCommand{  Expression = "1+2+3" };
        var task = handle.Handle(command, CancellationToken.None);
        double result = await task;
        Assert.Equal(6, result);

        command = new CalculateCommand{  Expression = "2*3*5+1" };
        task = handle.Handle(command, CancellationToken.None);
        result = await task;
        Assert.Equal(31, result);

        command = new CalculateCommand{  Expression = "20/10-3" };
        task = handle.Handle(command, CancellationToken.None);
        result = await task;
        Assert.Equal(-1, result);


    }
}
