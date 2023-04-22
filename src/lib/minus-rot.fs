\ lib/minus-rot.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

get-order get-current

target-definitions

: -rot ( x1 x2 x3 -- x3 x1 x2 )
  0 ix l ftx, \ ld l,(ix+0)
  1 ix h ftx, \ ld h,(ix+1)
  2 ix e ftx, \ ld e,(ix+2)
  3 ix d ftx, \ ld d,(ix+3)
  4 ix c ftx, \ ld c,(ix+4)
  5 ix b ftx, \ ld b,(ix+5)
  e 0 ix stx, \ ld (ix+0),e
  d 1 ix stx, \ ld (ix+1),d
  c 2 ix stx, \ ld (ix+2),c
  b 3 ix stx, \ ld (ix+3),b
  l 4 ix stx, \ ld (ix+4),l
  h 5 ix stx, \ ld (ix+5),h
  ;

  \ doc{
  \
  \ -rot ( x1 x2 x3 -- x3 x1 x2 ) "minus-rot"
  \
  \ Rotate the top three stack entries in reverse order.
  \
  \ See also: `rot`, `over`, `tuck`, `swap`, `roll`, `pick`, `unpick`.
  \
  \ }doc

set-current set-order
