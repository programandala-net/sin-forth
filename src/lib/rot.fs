\ lib/rot.fs
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

: rot ( x1 x2 x3 -- x2 x3 x1 )
  0 ix l ftx, \ ld l,(ix+0)
  1 ix h ftx, \ ld h,(ix+1)
  2 ix e ftx, \ ld e,(ix+2)
  3 ix d ftx, \ ld d,(ix+3)
  4 ix c ftx, \ ld c,(ix+4)
  5 ix b ftx, \ ld b,(ix+5)
  c 0 ix stx, \ ld (ix+0),c
  b 1 ix stx, \ ld (ix+1),b
  l 2 ix stx, \ ld (ix+2),l
  h 3 ix stx, \ ld (ix+3),h
  e 4 ix stx, \ ld (ix+4),e
  d 5 ix stx, \ ld (ix+5),d
  ;

  \ doc{
  \
  \ rot ( x1 x2 x3 -- x2 x3 x1 )
  \
  \ Rotate the top three stack entries.
  \
  \ See also: `-rot`, `over`, `tuck`, `swap`, `roll`, `pick`.
  \
  \ }doc
