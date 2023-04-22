\ lib/drop.fs

\ This file is part of Sin Forth.

\ This file adds `drop` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

get-order get-current

target-definitions

: drop ( x -- )
  ix incp, \ inc ix
  ix incp, \ inc ix 
  ;        \ ret

  \ doc{
  \
  \ drop ( x -- )
  \
  \ Remove _x_ from the stack.
  \
  \ See also: `2drop`, `nip`.
  \
  \ }doc

set-current set-order
