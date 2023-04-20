#! /usr/bin/env gforth

\ test_literal.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230420T1138+0200.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/compiler.fs

40000 set-origin
s" test_literal" set-filename

begin-program

require sin_forth/lib/emit.fs
require sin_forth/lib/literal.fs

: game ( -- ) 65 literal emit 66 literal emit 67 literal emit ;

4 data-stack

end-program

\ ==============================================================
\ Change log {{{1

\ 2020-12-10: Start.
\
\ 2023-04-20: Update with `data-stack`.
