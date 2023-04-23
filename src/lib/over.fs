\ lib/over.fs
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

require push-hl.fs \ `push-hl`

get-order get-current

target-definitions

: over ( x1 x2 -- x1 x2 x1 )
  2 ix l ftx, \ ld l,(ix+2)
  3 ix h ftx, \ ld h,(ix+3)
  push-hl     \ call push_hl
  ;           \ ret

  \ doc{
  \
  \ over ( x1 x2 -- x1 x2 x1 )
  \
  \ Place a copy of _x1_ on top of the stack.
  \
  \ See also: `dup`, `swap`, `2over`.
  \
  \ }doc

set-current set-order
