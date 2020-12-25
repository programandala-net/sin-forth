#! /usr/bin/env gforth

\ test_type.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260049.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/compiler.fs

40000 set-origin
s" test_type" set-filename

begin-program

require sin_forth/lib/drop.fs
require sin_forth/lib/emit.fs
require sin_forth/lib/literal.fs
require sin_forth/lib/s-literal.fs
require sin_forth/lib/type.fs

: the-end ( -- ) "The End" sliteral type ;

boot-here
exx, h push,

'a' literal emit
'b' literal emit
'c' literal emit
13 literal emit

'1' literal emit
'2' literal emit
'3' literal emit
13 literal emit

s" abc" sliteral type
13 literal emit

s" 123" sliteral type
13 literal emit

the-end

h pop, exx,
ret,

4 data-stack-here

end-program

\ ==============================================================
\ Change log {{{1

\ 2020-12-25: Start.
\
\ 2020-12-26: Complete.
