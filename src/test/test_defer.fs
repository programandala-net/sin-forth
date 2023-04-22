\ test_defer.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1933+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

40000 set-origin

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
