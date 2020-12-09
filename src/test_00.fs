#! /usr/bin/env gforth

\ test_00.fs

\ This file is part of:

\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012081731.
\ See change log at the end of the file.

\ ==============================================================
\ Description {{{1

\ This file is a test program compilable by Sin Forth.

\ ==============================================================
\ Requirements and configuration {{{1

require sin_forth.fs

40000 set-origin
s" test00" set-filename

begin-program

\ require lib/allot.fs
\ require lib/cell.fs
\ require lib/comma.fs
require lib/constant.fs
\ require lib/d-p.fs
require lib/emit.fs
\ require lib/fetch.fs
\ require lib/here.fs
\ require lib/literal.fs
\ require lib/init-data-stack.fs
\ require lib/plus-store.fs
\ require lib/pop-de.fs
\ require lib/pop-hl-de.fs
\ require lib/pop-hl.fs
\ require lib/push-de.fs
\ require lib/push-de-hl.fs
\ require lib/push-hl.fs
\ require lib/s-p-0.fs
\ require lib/store.fs

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
