# rscs

**Minimal C# to Rust FFI call**

1. Compile Rust code (tested on Windows):

```bash
cargo build --release ; cp .\target\release\rscs.dll ..\..\cs\rscs\rscs\add.dll
```

2. Compile the C# project.
3. Run the program in the terminal.

