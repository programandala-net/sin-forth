\ lib/two-plus.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1824+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

get-order get-current

target-definitions

: 2+ ( n1 -- n2 )

  \ XXX slow variant:
  \ pop-hl h incp, h incp, push-hl ;

  \ XXX fast variant:
  0 ix l ftx, \ ld l,(ix+0)
  1 ix h ftx, \ ld h,(ix+1)
  h incp,     \ inc hl
  h incp,     \ inc hl
  l 0 ix stx, \ ld (ix+0),l
  h 1 ix stx, \ ld (ix+1),h
  ;           \ ret

set-current set-order
