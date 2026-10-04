using Utility;

namespace Codex.Common
{
    // Renamed from "Codex" so it doesn't clash with the enclosing namespace name.
    public partial struct CodexMatrix
    {
        public object[] matrix;
        public int[] stride;
        public int[] shape;
        public int ndim;
        public string device;
        public string dtype;
    }

    public static class Ops
    {
        public static CodexMatrix matrix(double[] array, string dtype = "float64")
        {
            object[] sanitized_array = Helpers.sanitize(array, dtype);

            CodexMatrix nmatrix = new CodexMatrix();
            nmatrix.matrix = sanitized_array;
            nmatrix.shape = new int[] { array.Length };
            nmatrix.stride = Helpers.compute_strides(nmatrix.shape);
            nmatrix.ndim = nmatrix.shape.Length;
            nmatrix.device = "cpu";
            nmatrix.dtype = dtype;

            return nmatrix;
        }
    }
}
