\ lib/two-over.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require push-de-hl.fs \ `push-de-hl`

: 2over ( x1 x2 x3 x4 -- x1 x2 x3 x4 x1 x2 )
  4 ix l ftx, \ ld l,(ix+4)
  5 ix h ftx, \ ld h,(ix+5)
  6 ix e ftx, \ ld e,(ix+6)
  7 ix d ftx, \ ld d,(ix+7)
  push-de-hl  \ call push_de_hl
  ;           \ ret

  \ doc{
  \
  \ 2over ( x1 x2 x3 x4 -- x1 x2 x3 x4 x1 x2 ) "two-over"
  \
  \ Copy cell pair _x1 x2_ on top of the stack.
  \
  \ See also: `over`, `2swap`.
  \
  \ }doc
