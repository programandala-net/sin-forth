\ lib/two-drop.fs
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

: 2drop ( x1 x2 -- )
  ix incp, \ inc ix
  ix incp, \ inc ix
  ix incp, \ inc ix
  ix incp, \ inc ix
  ;        \ ret

  \ doc{
  \
  \ 2drop ( x1 x2 -- ) "two-drop"
  \
  \ Remove cell pair _x1 x2_ from the stack.
  \
  \ See also: `drop`, `nip`.
  \
  \ }doc

set-current set-order
