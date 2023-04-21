\ test_defer.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230421T1407+0200.
\ See change log at the end of the file.

\ ==============================================================

40000 set-origin
s" test_defer" set-filename

begin-program

require sin_forth/lib/defer.fs
require sin_forth/lib/defer-store.fs
require sin_forth/lib/emit.fs
require sin_forth/lib/literal.fs
require sin_forth/lib/tick.fs

defer any

: letters ( -- )
  'a' literal emit
  'b' literal emit
  'c' literal emit ;

: numbers ( -- )
  '1' literal emit
  '2' literal emit
  '3' literal emit ;

: run ( -- )
  ' letters literal ' any literal defer! any
  ' numbers literal ' any literal defer! any ;

4 data-stack

end-program

\ ==============================================================
\ Change log {{{1

\ 2020-12-10: Start.
\
\ 2020-12-11: Complete.
\
\ 2023-04-20: Update with `data-stack`.
