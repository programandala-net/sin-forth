\ test_literal.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1746+0200.

\ ==============================================================

40000 set-origin
s" test_literal" set-filename

begin-program

require sin_forth/lib/emit.fs
require sin_forth/lib/literal.fs

: game ( -- ) 65 literal emit 66 literal emit 67 literal emit ;

4 data-stack

end-program
