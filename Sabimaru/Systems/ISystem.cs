namespace Sabimaru.Systems
{
	using System;
	using System.Collections.Generic;

	public interface ISystem
	{
		List<Type> ComponentTypes { get; }
	}
}