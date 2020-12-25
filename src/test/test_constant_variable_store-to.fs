#! /usr/bin/env gforth

\ test_constant_variable_store-to.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012101935.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/compiler.fs

40000 set-origin
s" test_constant_variable_store-to" set-filename

begin-program

require sin_forth/lib/constant.fs
require sin_forth/lib/emit.fs
require sin_forth/lib/fetch.fs
require sin_forth/lib/store.fs
require sin_forth/lib/store-to.fs
require sin_forth/lib/variable.fs

65 constant letter-1   \ "A"
   variable letter-2
67 constant letter-3   \ "C"

: run ( -- )

  66 literal  letter-2 ! \ "B"

  letter-1   emit       \ "A"
  letter-2 @ emit       \ "B"
  letter-3   emit       \ "C"

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
