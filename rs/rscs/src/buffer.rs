#[repr(C)]
pub struct Buffer {
    pub pointer: *mut u8,
    pub length: usize
}

impl Buffer {
    pub fn new(data: &mut Vec<u8>) -> Self {
        let pointer = data.as_mut_ptr();
        let length = data.len();
        Self { pointer, length }
    }
}