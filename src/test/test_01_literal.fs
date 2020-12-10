#! /usr/bin/env gforth

\ test_01_literal.fs

\ This file is part of:

\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012101934.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/compiler.fs

40000 set-origin
s" test_01_literal" set-filename

begin-program

require sin_forth/lib/emit.fs
require sin_forth/lib/literal.fs

: game ( -- ) 65 literal emit 66 literal emit 67 literal emit ;

4 data-stack-here

end-program

\ ==============================================================
\ Change log {{{1

\ 2020-12-10: Start.
