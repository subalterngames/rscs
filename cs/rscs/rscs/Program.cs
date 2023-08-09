using System.Runtime.InteropServices;


namespace rscs;

public class Program
{
    private static void Main(string[] args)
    {
        int c = add(1, 2);
        Console.WriteLine(c);
        
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
    }

    [DllImport("add.dll", CallingConvention =  CallingConvention.Cdecl)]
    static extern unsafe void add_one(byte* pointer, uint length);  
    
    
    [DllImport("add.dll", CallingConvention =  CallingConvention.Cdecl)]
    static extern int add(int a, int b);  
}