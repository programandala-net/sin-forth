#! /usr/bin/env gforth

\ test_constant_variable_store-to.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230420T0855+0200.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/compiler.fs

40000 set-origin
s" test_constant_variable_store-to" set-filename

begin-program

require sin_forth/lib/constant.fs
require sin_forth/lib/c-fetch.fs
require sin_forth/lib/c-store.fs
require sin_forth/lib/c-variable.fs
require sin_forth/lib/emit.fs
require sin_forth/lib/fetch.fs
require sin_forth/lib/store.fs
require sin_forth/lib/store-to.fs
require sin_forth/lib/variable.fs

65 constant  letter-1   \ "A"
   variable  letter-2
67 constant  letter-3   \ "C"
   cvariable letter-4

: run ( -- )

  66 literal letter-2  ! \ "B"
  68 literal letter-4 c! \ "D"

  letter-1    emit       \ "A"
  letter-2  @ emit       \ "B"
  letter-3    emit       \ "C"
  letter-4 c@ emit       \ "D"

  letter-1 letter-2 !
  letter-2 @ emit       \ "A"
  68 literal !> letter-3
  letter-3   emit       \ "D"

  ;

4 data-stack-here

end-program

\ ==============================================================
\ Change log {{{1

\ 2020-12-10: Start.
\
\ 2020-12-26: Add `cvariable`, `c@`, `c!`.
\
\ 2023-04-20: Update library filename.
