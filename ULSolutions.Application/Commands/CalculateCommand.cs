using MediatR;
namespace ULSolutions.Application.Commands;

public class CalculateCommand : IRequest<double>
{
    public required string Expression { get; set; }
}
