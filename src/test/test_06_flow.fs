#! /usr/bin/env gforth

\ test_06_flow.fs

\ This file is part of:

\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012130108.
\ See change log at the end of the file.

\ ==============================================================

\ bye \ XXX TMP

require sin_forth/compiler.fs

40000 set-origin
s" test_06_flow" set-filename

begin-program

require sin_forth/lib/begin.fs     \ `begin`
require sin_forth/lib/dup.fs       \ `dup`
require sin_forth/lib/emit.fs      \ `emit`
require sin_forth/lib/equals.fs    \ `=`
require sin_forth/lib/if.fs        \ `if`
require sin_forth/lib/literal.fs   \ `literal`
require sin_forth/lib/one-minus.fs \ `1-`
require sin_forth/lib/one-plus.fs  \ `1+`
require sin_forth/lib/repeat.fs    \ `repeat`
require sin_forth/lib/then.fs      \ `then`
require sin_forth/lib/until.fs     \ `until`
require sin_forth/lib/while.fs     \ `while`

boot-here

1 literal if 'A' literal emit then
0 literal if 'X' literal emit then
2 literal if 'B' literal emit then
0 literal if 'X' literal emit then
3 literal if 'C' literal emit then

\ Type from 'a' to 'z':
13 literal emit
'a' literal
begin dup '{' literal = 0 literal =
while dup emit 1+
repeat
\ XXX TODO drop

\ Type from 'z' to 'a'
13 literal emit
'z' literal
begin dup emit 1- dup '`' literal =
until
\ XXX TODO drop

ret,

4 data-stack-here

end-program

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-13: Add `begin`, `while`, `repeat`, `until`.
