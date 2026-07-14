using CodeInspector.Core.Context;
using CodeInspector.Models;

namespace CodeInspector.Fix.Models;

public class FixContext
{
    public Issue Issue { get; set; } = null!;

    public MethodContext MethodContext { get; set; } = null!;
}