
using System;
using Codex.Common;

namespace std {
    class Program {
	public static void Main(string[] args) {
	    
	    CodexMatrix m = Ops.matrix(new double[] { 1.5, 2.5, 3.5 }, "f32");
	    CodexMatrix n = Ops.matrix(new double[] { 1, 2, 3}, "f32");

	    CodexMatrix r = m+n;
	    Console.WriteLine($"[{string.Join(", ", r.matrix)}]");
	}
    }
}
