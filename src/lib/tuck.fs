\ lib/tuck.fs
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

require push-hl.fs \ `push-hl`

: tuck ( x1 x2 -- x2 x1 x2 )
  0 ix l ftx, \ ld l,(ix+0)
  1 ix h ftx, \ ld h,(ix+1)
  2 ix e ftx, \ ld e,(ix+2)
  3 ix d ftx, \ ld d,(ix+3)
  e 0 ix stx, \ ld (ix+0),e
  d 1 ix stx, \ ld (ix+1),d
  l 2 ix stx, \ ld (ix+2),l
  h 3 ix stx, \ ld (ix+3),h
  push-hl     \ call push_hl
  ;           \ ret

  \ doc{
  \
  \ tuck ( x1 x2 -- x2 x1 x2 )
  \
  \ Copy the first (top) stack item below the second stack item.
  \
  \ See also: `dup`, `over`, `nip`, `nup`.
  \
  \ }doc
