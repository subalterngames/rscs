mod buffer;
use buffer::Buffer;
use std::mem::forget;
use std::slice::from_raw_parts_mut;

/// A safe and simple FFI call.
#[no_mangle]
pub extern "C" fn add(a: i32, b: i32) -> i32 {
    a + b
}

/// Add one to an array defined by `pointer` and `length`.
///
/// # Safety
///
/// This is totally safe because we never need to create our own pointer.
#[no_mangle]
pub unsafe extern "C" fn add_one(pointer: *mut u8, length: usize) {
    let slice = from_raw_parts_mut(pointer, length);
    slice.iter_mut().for_each(|v| *v += 1);
}

/// Add one to an array defined by `pointer` and `length`, but this returns a new buffer.
///
/// # Safety
///
/// Very unsafe! You need to call `deallocate_buffer()` after.
#[no_mangle]
pub unsafe extern "C" fn add_one_new(pointer: *mut u8, length: usize) -> Buffer {
    let mut vec = from_raw_parts_mut(pointer, length).to_vec();
    vec.iter_mut().for_each(|v| *v += 1);
    let buffer = Buffer::new(&mut vec);
    forget(vec);
    buffer
}

/// Drop an allocated `Buffer` defined by `pointer` and `length`.
///
/// # Safety
///
/// Very unsafe! But you need to call this after `add_one_new()`.
#[no_mangle]
pub unsafe extern "C" fn deallocate_buffer(pointer: *mut u8, length: usize) {
    drop(Vec::from_raw_parts(pointer, length, length));
}
