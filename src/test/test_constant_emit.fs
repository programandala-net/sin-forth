\ test_constant_emit.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230421T1407+0200.

\ ==============================================================

40000 set-origin
s" test_constant_emit" set-filename

begin-program

require sin_forth/lib/constant.fs
require sin_forth/lib/emit.fs

65 constant zx

boot-here
zx emit ret,

4 data-stack

end-program
