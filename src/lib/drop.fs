\ lib/drop.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1823+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

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
