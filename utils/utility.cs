using System;

namespace Utility
{
    public static class Helpers
    {
        public static object[] sanitize(double[] array, string dtype)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            object[] vector = new object[array.Length];
	    
            for (int i = 0; i < array.Length; i++)
            {
                switch (dtype)
                {
                    case "f64": vector[i] = array[i]; break;
                    case "f32": vector[i] = (float)array[i]; break;
                    case "i64": vector[i] = (long)array[i]; break;
                    case "i32": vector[i] = (int)array[i]; break;
		    case "i16": vector[i] = (short)array[i]; break;
		    case "i8" : vector[i] = (sbyte)array[i]; break;
		    case "u8" : vector[i] = (byte)array[i]; break;
		    case "u16": vector[i] = (ushort)array[i]; break;
		    case "u32": vector[i] = (uint)array[i]; break;
		    case "u64": vector[i] = (ulong)array[i]; break;
		    
                    default: throw new ArgumentException($"Unsupported dtype: {dtype}", nameof(dtype));
                }
            }
            return vector;
        }

        public static int[] compute_strides(int[] shape)
        {
            int[] strides = new int[shape.Length];
            int current = 1;
            for (int i = shape.Length - 1; i >= 0; i--)
            {
                strides[i] = current;
                current *= shape[i];
            }
            return strides;
        }
    }
}
