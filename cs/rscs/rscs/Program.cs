using System.Runtime.InteropServices;


namespace rscs;

public class Program
{
    private static void Main(string[] args)
    {
        int c = add(1, 2);
        Console.WriteLine("Add: " + c);
        Console.WriteLine("Add no malloc:");
        byte[] test = { 0, 1, 2, 3, 4, 5, 7, 8, 9 };
        uint length = (uint)test.Length;
        unsafe
        {
            fixed (byte* pointer = test)
            {
                add_one(pointer, length);
            }
        }
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine(test[i]);
        }
        Console.WriteLine("Add no alloc:");
        byte[] result;
        unsafe
        {
            fixed (byte* pointer = test)
            {
                Buffer buffer = add_one_new(pointer, length);
                Console.WriteLine("Got buffer");
                result = GetArray(buffer);
                Console.WriteLine("Got array");
                deallocate_buffer(buffer.pointer, buffer.length);
                Console.WriteLine("Deallocated");
            }
        }
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine(result[i]);
        }
    }
    
    private static byte[] GetArray(Buffer buffer)
    {
        byte[] array = new byte[buffer.length];
        unsafe
        {
            Marshal.Copy((IntPtr)buffer.pointer, array, 0, array.Length);         
        }
        return array;
    }

    [DllImport("add.dll", CallingConvention =  CallingConvention.Cdecl)]
    private static extern unsafe void add_one(byte* pointer, uint length);  
    
    [DllImport("add.dll", CallingConvention =  CallingConvention.Cdecl)]
    private static extern unsafe Buffer add_one_new(byte* pointer, uint length);  
    
    [DllImport("add.dll", CallingConvention =  CallingConvention.Cdecl)]
    private static extern unsafe void deallocate_buffer(byte* pointer, uint length);  
    
    
    [DllImport("add.dll", CallingConvention =  CallingConvention.Cdecl)]
    private static extern int add(int a, int b);  
}