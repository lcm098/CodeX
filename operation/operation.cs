
// Operation.cs [+, -, *, /]

namespace Codex.Common {

    public partial struct CodexMatrix {
	public static CodexMatrix operator +(CodexMatrix a, CodexMatrix b) {

	    object[] x = a.matrix;
	    object[] y = b.matrix;

	    if (!SameShape(a.shape, b.shape)) {
		throw new Exception("while doing elements-wise addition, shape does not matched");
	    }

	    else {
		if (a.dtype != b.dtype) {
		    throw new Exception("While doing element-wise addition, datatype does not matched");
		}
		object[] data = new object[x.Length];
		
		for(int i=0; i<x.Length; i++) {
		    data[i] = (dynamic)x[i] + (dynamic)y[i];
		}
 
		CodexMatrix c = new CodexMatrix();
		c.matrix = data;
		c.shape = (int[])a.shape.Clone();
		c.stride = (int[])a.stride.Clone();
		c.ndim = a.ndim;
		c.device = a.device;
		c.dtype = a.dtype;
 
		return c;
	    }
	}

	private static bool SameShape(int[] s1, int[] s2) {
	    if (s1.Length != s2.Length) return false;
	    for (int i = 0; i < s1.Length; i++) {
		if (s1[i] != s2[i]) return false;
	    }
	    return true;
	}
    }
}
