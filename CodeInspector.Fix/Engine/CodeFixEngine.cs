using CodeInspector.Core.Context;
using CodeInspector.Fix.Interfaces;
using CodeInspector.Fix.Models;
using CodeInspector.Models;

namespace CodeInspector.Fix.Engine;

public class CodeFixEngine
{
	private readonly Dictionary<string, ICodeFixProvider> _providers = new();

	public void Register(ICodeFixProvider provider)
	{
		_providers[provider.RuleId] = provider;
	}

	public FixResult? Generate(
		Issue issue,
		MethodContext context)
	{
		if (!_providers.TryGetValue(issue.RuleId, out var provider))
			return null;

		return provider.Generate(issue, context);
	}
}