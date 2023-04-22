\ test_maths.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1745+0200.

\ ==============================================================

40000 set-origin
s" test_maths" set-filename

begin-program

require sin_forth/lib/emit.fs
require sin_forth/lib/literal.fs
require sin_forth/lib/minus.fs     \ `-`
require sin_forth/lib/plus.fs      \ `+`
require sin_forth/lib/one-plus.fs  \ `1+`
require sin_forth/lib/one-minus.fs \ `1-`
require sin_forth/lib/store.fs     \ `!`
require sin_forth/lib/two-plus.fs  \ `2+`
require sin_forth/lib/two-minus.fs \ `2-`

boot-here

60 literal  05 literal + emit \ "A"
01 literal $41 literal + emit \ "B"
68 literal  01 literal - emit \ "C"
99 literal  31 literal - emit \ "D"
68 literal  1+           emit \ "E"
71 literal  1-           emit \ "F"
69 literal  2+           emit \ "G"
74 literal  2-           emit \ "H"

$00FF literal 1+ 1- emit \ "COPY"

ret,

4 data-stack

end-program
