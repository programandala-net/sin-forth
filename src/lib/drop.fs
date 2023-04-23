\ lib/drop.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

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
