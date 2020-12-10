#! /usr/bin/env gforth

\ test_00_constant_emit.fs

\ This file is part of:

\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012100233.
\ See change log at the end of the file.

\ ==============================================================
\ Description {{{1

\ This file is a test program compilable by Sin Forth.

\ ==============================================================
\ Requirements and configuration {{{1

require sin_forth/compiler.fs

40000 set-origin
s" test00" set-filename

begin-program

require sin_forth/lib/constant.fs
require sin_forth/lib/emit.fs

\ ==============================================================
\ Code {{{1

65 constant zx

: game ( -- ) zx emit ;

4 data-stack-here

end-program

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from the main source.
\
\ 2020-12-08: Update with `begin-program`, `end-program`,
\ `set-origin`, `set-filename`.
\
\ 2020-12-09: Compiled and executed and executed in an emulated ZX
\ Spectrum 128: it prints an "A" and returns to BASIC.
\
\ 2020-12-10: Moved into <test> and renamed from <test_00.fs> to
\ <test_00_constant_emit.fs>.
