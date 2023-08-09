mod buffer;
use std::slice::from_raw_parts_mut;
use buffer::Buffer;

#[no_mangle]
pub extern "cdecl" fn add_one(pointer: *mut u8, length: usize) -> Buffer {
    unsafe {
        let v = from_raw_parts_mut(pointer, length);
        v.iter_mut().for_each(|v| *v += 1);
    }
    Buffer::new(pointer, length)
}