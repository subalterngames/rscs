/// A buffer of u8 data.
#[repr(C)]
pub struct Buffer {
    pub pointer: *mut u8,
    pub length: usize,
}

impl Buffer {
    pub fn new(pointer: *mut u8, length: usize) -> Self {
        Self { pointer, length }
    }
}