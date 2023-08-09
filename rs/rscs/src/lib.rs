use std::slice::from_raw_parts_mut;

#[no_mangle]
pub extern fn add_one(pointer: *mut u8, length: u32) {
    unsafe {
        let v = from_raw_parts_mut(pointer, length as usize);
        v.iter_mut().for_each(|v| *v += 1);
    }
}

#[no_mangle]
pub extern "C" fn add(a: i32, b: i32) -> i32 {
    a + b
}