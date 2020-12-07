#! /usr/bin/env gforth

\ test_00.fs

\ This file is part of:

\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012072153.
\ See change log at the end of the file.

\ ==============================================================
\ Description {{{1

\ This file is a test program compilable by Sin Forth.

\ ==============================================================
\ Requirements {{{1

require sin_forth.fs

\ require lib/allot.fs
\ require lib/cell.fs
\ require lib/comma.fs
require lib/constant.fs
\ require lib/d-p.fs
\ require lib/fetch.fs
\ require lib/here.fs
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

compiler-definitions

cr .( The application is compiled at ) memory> @ .

target-definitions

1001 constant zx

: game ( -- x ) zx ;

game

forth-definitions

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from the main source.
