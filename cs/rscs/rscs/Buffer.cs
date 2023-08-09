using System.Runtime.InteropServices;

namespace rscs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Buffer
{
    public byte* pointer;
    public uint length;
}