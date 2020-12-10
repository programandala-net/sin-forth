#! /usr/bin/env gforth

\ test_02_tick.fs

\ This file is part of:

\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012110038.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/compiler.fs

40000 set-origin
s" test_02_tick" set-filename

begin-program

require sin_forth/lib/constant.fs
require sin_forth/lib/emit.fs
require sin_forth/lib/tick.fs
require sin_forth/lib/variable.fs

'Z' constant zx

'X' variable spectrum

: game ( -- ) zx emit spectrum emit ;

\ XXX REMARK The disassembly of this instructions should show that HL
\ is loaded with the corresponding defitinion address:

' zx        h ldp#, \ ld hl,zx_body
' spectrum  h ldp#, \ ld hl,spectrum_body
' game      h ldp#, \ ld hl,game_xt

4 data-stack-here

end-program

\ ==============================================================
\ Change log {{{1

\ 2020-12-10: Start.
