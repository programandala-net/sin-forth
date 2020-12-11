#! /usr/bin/env gforth

\ test_05_maths.fs

\ This file is part of:

\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012111507.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/compiler.fs

40000 set-origin
s" test_05_maths" set-filename

begin-program

require sin_forth/lib/emit.fs
require sin_forth/lib/literal.fs
require sin_forth/lib/minus.fs
require sin_forth/lib/plus.fs \ `+`

boot-here

60 literal  05 literal + emit \ "A"
01 literal $41 literal + emit \ "B"
68 literal  01 literal - emit \ "C"
99 literal  31 literal - emit \ "D"
ret, 

4 data-stack-here

end-program

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
